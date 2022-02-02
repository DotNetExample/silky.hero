using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.Exceptions;
using Silky.Core.Extensions;
using Silky.EntityFrameworkCore.Extensions;
using Silky.Hero.Common.Enums;
using Silky.Position.Application.Contracts.Position;
using Silky.Position.Application.Contracts.Position.Dtos;
using Silky.Position.Domain;

namespace Silky.Position.Application.Position;

public class PositionAppService : IPositionAppService
{
    private readonly IPositionDomainService _positionDomainService;

    public PositionAppService(IPositionDomainService positionDomainService)
    {
        _positionDomainService = positionDomainService;
    }

    public Task CreateAsync(CreatePositionInput input)
    {
        return _positionDomainService.CreateAsync(input);
    }

    public Task UpdateAsync(UpdatePositionInput input)
    {
        return _positionDomainService.UpdateAsync(input);
    }

    public async Task<GetPositionOutput> GetAsync(long id)
    {
        var position = await _positionDomainService.PositionRepository
            .AsQueryable(false)
            .Include(p => p.PositionOrganizations)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (position == null)
        {
            throw new UserFriendlyException($"不存在id为{id}的职位信息");
        }

        var positionOutput = position.Adapt<GetPositionOutput>();
        await positionOutput.SetOrganization();
        return positionOutput;
    }

    public Task DeleteAsync(long id)
    {
        return _positionDomainService.DeleteAsync(id);
    }

    public async Task<PagedList<GetPositionPageOutput>> GetPageAsync(GetPositionPageInput input)
    {
        var pageList = await _positionDomainService.PositionRepository
            .AsQueryable(false)
            .Include(p => p.PositionOrganizations)
            .Where(!input.Name.IsNullOrEmpty(), p => p.Name.Contains(input.Name))
            .Where(input.Status.HasValue, p => p.Status == input.Status)
            .OrderByDescending(p => p.Sort)
            .ProjectToType<GetPositionPageOutput>()
            .ToPagedListAsync(input.PageIndex, input.PageSize);
        foreach (var item in pageList.Items)
        {
            await item.SetOrganization();
        }

        return pageList;
    }

    public async Task<bool> HasPositionAsync(long positionId)
    {
        return await _positionDomainService.PositionRepository.FindOrDefaultAsync(positionId) != null;
    }

    public async Task<ICollection<GetPositionOutput>> GetListAsync(long? organizationId, string name)
    {
        var list = await _positionDomainService.PositionRepository
            .AsQueryable(false)
            .Include(p => p.PositionOrganizations)
            .Where(organizationId.HasValue,
                p => p.IsPublic || p.PositionOrganizations.Any(po => po.OrganizationId == organizationId))
            .Where(!name.IsNullOrEmpty(), p => p.Name.Contains(name))
            .Where(p => p.Status == Status.Valid)
            .ProjectToType<GetPositionOutput>()
            .ToListAsync();
        foreach (var item in list)
        {
            await item.SetOrganization();
        }

        return list;
    }
}