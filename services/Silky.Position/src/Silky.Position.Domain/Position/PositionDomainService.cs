using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Identity.Application.Contracts.User;
using Silky.Organization.Application.Contracts.Organization;
using Silky.Position.Application.Contracts.Position.Dtos;

namespace Silky.Position.Domain;

public class PositionDomainService : IPositionDomainService
{
    private readonly IUserAppService _userAppService;
    private readonly IOrganizationAppService _organizationAppService;

    public PositionDomainService(IRepository<Position> positionRepository,
        IUserAppService userAppService,
        IOrganizationAppService organizationAppService)
    {
        PositionRepository = positionRepository;
        _userAppService = userAppService;
        _organizationAppService = organizationAppService;
    }

    public IRepository<Position> PositionRepository { get; }

    public async Task CreateAsync(CreatePositionInput input)
    {
        var exsitPosition = await PositionRepository.FirstOrDefaultAsync(p => p.Name == input.Name);
        if (exsitPosition != null)
        {
            throw new UserFriendlyException($"已经存在名称为{input.Name}的职位");
        }

        var position = input.Adapt<Position>();
        position.SetPublic(input.IsPublic);
        if (!position.IsPublic)
        {
            await CheckExsitOrganizations(input.OrganizationIds);
            position.AddOrganizationIds(input.OrganizationIds.ToArray());
        }

        await PositionRepository.InsertAsync(position);
    }
    
    public async Task UpdateAsync(UpdatePositionInput input)
    {
        var position = await PositionRepository.Include(p => p.PositionOrganizations)
            .FirstOrDefaultAsync(p => p.Id == input.Id);
        if (position == null)
        {
            throw new UserFriendlyException($"不存在Id为{input.Id}的职位");
        }

        if (!position.Name.Equals(input.Name))
        {
            var exsitPosition = await PositionRepository.FirstOrDefaultAsync(p => p.Name == input.Name);
            if (exsitPosition != null)
            {
                throw new UserFriendlyException($"已经存在名称为{input.Name}的职位");
            }
        }

        if (!input.IsPublic)
        {
            if (position.IsPublic && await _userAppService.HasPositionUsersAsync(position.Id))
            {
                throw new UserFriendlyException($"公共职位已经被分配给用户,无法修改所属部门信息");
            }

            var removeOrganizationIds =
                position.PositionOrganizations.Select(p => p.OrganizationId).Except(input.OrganizationIds).ToArray();
            foreach (var organizationId in removeOrganizationIds)
            {
                if (await _userAppService.HasSubsidiaryUsersAsync(organizationId, position.Id))
                {
                    var organizationInfo = await _organizationAppService.GetAsync(organizationId);
                    throw new BusinessException($"{organizationInfo.Name}已经存在分配了该岗位的用户,请先移除相关用户后再调整岗位部门信息");
                }
            }
            await CheckExsitOrganizations(input.OrganizationIds);
        }
       

        position = input.Adapt(position);
        position.SetPublic(input.IsPublic);
        RemoveFromOrganizations(position,
            position.PositionOrganizations.Select(p => p.OrganizationId).Except(input.OrganizationIds).ToArray());
        AddToOrganizations(position,input.OrganizationIds.Except(position.PositionOrganizations.Select(p => p.OrganizationId)).ToArray());
        await PositionRepository.UpdateAsync(position);
    }

    private void AddToOrganizations(Position position, long[] organizationIds)
    {
        position.AddOrganizationIds(organizationIds);
    }

    private void RemoveFromOrganizations(Position position, long[] organizationIds)
    {
        position.RemoveOrganizationIds(organizationIds);
    }

    public async Task DeleteAsync(long id)
    {
        var position = await PositionRepository.FindOrDefaultAsync(id);
        if (position == null)
        {
            throw new UserFriendlyException($"不存在id为{id}的职位信息");
        }

        if (await _userAppService.HasPositionUsersAsync(id))
        {
            throw new UserFriendlyException($"该职位存在用户,无法删除");
        }

        await PositionRepository.DeleteAsync(position);
    }
    
    private async Task CheckExsitOrganizations(IEnumerable<long> organizationIds)
    {
        foreach (var organizationId in organizationIds)
        {
            if (!await _organizationAppService.HasOrganizationAsync(organizationId))
            {
                throw new UserFriendlyException($"不存在Id为{organizationId}的组织部门");
            }
        }
    }
}