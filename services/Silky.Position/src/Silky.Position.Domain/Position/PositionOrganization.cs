using Silky.Hero.Common.EntityFrameworkCore.Entities;

namespace Silky.Position.Domain;

public class PositionOrganization : AuditedEntity
{
    public PositionOrganization()
    {
    }
    
    public PositionOrganization(long positionId,long organizationId)
    {
        PositionId = positionId;
        OrganizationId = organizationId;
    }

    public long PositionId { get; set; }

    public long OrganizationId { get; set; }
}