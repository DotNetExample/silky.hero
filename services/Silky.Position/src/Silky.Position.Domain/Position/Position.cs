using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Silky.Core.Exceptions;
using Silky.Hero.Common.EntityFrameworkCore.Entities;
using Silky.Hero.Common.Enums;

namespace Silky.Position.Domain;

public class Position : FullAuditedEntity, IHasConcurrencyStamp
{
    public Position()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString();
        PositionOrganizations = new List<PositionOrganization>();
    }

    [NotNull] public string Name { get; set; }
    
    public int Sort { get; set; }

    public string Remark { get; set; }

    public Status Status { get; set; }

    public bool IsPublic { get; internal protected set; }

    public void SetPublic(bool isPublic)
    {
        IsPublic = isPublic;
        if (IsPublic)
        {
            PositionOrganizations.Clear();
        }
    }

    public ICollection<PositionOrganization> PositionOrganizations { get; set; }

    public void AddOrganizationIds(params long[] organizationIds)
    {
        if (IsPublic)
        {
            throw new BusinessException("公共岗位不允许新增所属部门");
        }

        foreach (var organizationId in organizationIds)
        {
            if (!PositionOrganizations.Any(p => p.OrganizationId == organizationId && p.PositionId == Id))
            {
                PositionOrganizations.Add(new PositionOrganization(Id,organizationId));
            }
        }
    }

    public string ConcurrencyStamp { get; set; }

    public void RemoveOrganizationIds(long[] organizationIds)
    {
        if (IsPublic)
        {
            throw new BusinessException("公共岗位不允许移除所属部门");
        }
        foreach (var organizationId in organizationIds)
        {
            var positionOrganization =
                PositionOrganizations.FirstOrDefault(p => p.OrganizationId == organizationId && p.PositionId == Id);
            if (positionOrganization != null)
            {
                PositionOrganizations.Remove(positionOrganization);
            }
        }
    }
}