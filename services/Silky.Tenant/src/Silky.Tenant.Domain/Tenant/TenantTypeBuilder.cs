﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silky.EntityFrameworkCore.Entities.Configures;
using Silky.Hero.Common.EntityFrameworkCore.Modeling;
using Silky.Hero.Common.Enums;
using Silky.Tenant.Domain.Shared.Tenant;

namespace Silky.Tenant.Domain;

public class TenantTypeBuilder : IEntityTypeBuilder<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder, DbContext dbContext, Type dbContextLocator)
    {
        builder.ToTable(TenantDbProperties.DbTablePrefix + "Tenants", TenantDbProperties.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(TenantConsts.MaxNameLength)
            .HasColumnName(nameof(Tenant.Name));
        
        builder.Property(o => o.Remark)
            .IsRequired()
            .HasMaxLength(TenantConsts.MaxRemarkLength)
            .HasColumnName(nameof(Tenant.Remark));
        
        builder.Property(o => o.Status)
            .IsRequired()
            .HasDefaultValue(Status.Valid)
            .HasColumnName(nameof(Tenant.Status));
    }
}