using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.Hero.Common.EntityFrameworkCore.Modeling;

namespace Silky.Position.Domain;

public class PositionOrganizationTypeBuilder : IEntityTypeBuilder<PositionOrganization>
{
    public void Configure(EntityTypeBuilder<PositionOrganization> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable(PositionDbProperties.DbTablePrefix + "PositionOrganizations", PositionDbProperties.DbSchema);
        entityBuilder.ConfigureByConvention();
        entityBuilder.Property(o => o.PositionId)
            .IsRequired()
            .HasColumnName(nameof(PositionOrganization.PositionId));
        entityBuilder.Property(o => o.OrganizationId)
            .IsRequired()
            .HasColumnName(nameof(PositionOrganization.OrganizationId));
    }
}