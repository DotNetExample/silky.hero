﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Silky.Organization.EntityFrameworkCore.DbContexts;

#nullable disable

namespace Silky.Organization.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20220225133200_v1.13")]
    partial class v113
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Silky.Organization.Domain.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedTime");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletedTime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Name");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("ParentId");

                    b.Property<string>("Remark")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("Remark");

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Sort");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("TenantId");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConcurrencyStamp = "ef1d0ae8-1f02-4adf-bbd7-f6f6e6381435",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Silky.Hero社区",
                            Sort = 1,
                            Status = 1,
                            TenantId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ConcurrencyStamp = "18b71c25-21ad-45ae-a4f9-3c4904a36518",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Silky.Hero开发部",
                            ParentId = 1L,
                            Remark = "负责产品开发",
                            Sort = 2,
                            Status = 1,
                            TenantId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            ConcurrencyStamp = "d105c731-0413-4966-9602-869839df6d3c",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Silky.Hero后端开发部",
                            ParentId = 2L,
                            Remark = "负责服务段接口开发",
                            Sort = 3,
                            Status = 1,
                            TenantId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            ConcurrencyStamp = "1a4ec986-f626-46cc-b3e4-5da2f05e3d99",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Silky.Hero前端开发部",
                            ParentId = 2L,
                            Remark = "负责前端UI、交互开发",
                            Sort = 4,
                            Status = 1,
                            TenantId = 1L
                        },
                        new
                        {
                            Id = 5L,
                            ConcurrencyStamp = "92d1e834-a101-4d1f-92b0-7673f69e4eb8",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Silky.Hero测试部",
                            ParentId = 1L,
                            Remark = "负责产品测试",
                            Sort = 4,
                            Status = 1,
                            TenantId = 1L
                        },
                        new
                        {
                            Id = 6L,
                            ConcurrencyStamp = "6023d014-56b1-4899-a4cf-a46de9201a67",
                            CreatedTime = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Silky.Hero产品部",
                            ParentId = 1L,
                            Remark = "负责产品规划、设计",
                            Sort = 6,
                            Status = 1,
                            TenantId = 1L
                        });
                });

            modelBuilder.Entity("Silky.Organization.Domain.OrganizationPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedTime");

                    b.Property<long>("OrganizationId")
                        .HasColumnType("bigint")
                        .HasColumnName("OrganizationId");

                    b.Property<long>("PositionId")
                        .HasColumnType("bigint")
                        .HasColumnName("PositionId");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("TenantId");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationPositions", (string)null);
                });

            modelBuilder.Entity("Silky.Organization.Domain.OrganizationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreatedTime");

                    b.Property<long>("OrganizationId")
                        .HasColumnType("bigint")
                        .HasColumnName("OrganizationId");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoleId");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("TenantId");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationRoles", (string)null);
                });

            modelBuilder.Entity("Silky.Organization.Domain.Organization", b =>
                {
                    b.HasOne("Silky.Organization.Domain.Organization", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Silky.Organization.Domain.OrganizationPosition", b =>
                {
                    b.HasOne("Silky.Organization.Domain.Organization", "Organization")
                        .WithMany("OrganizationPositions")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Silky.Organization.Domain.OrganizationRole", b =>
                {
                    b.HasOne("Silky.Organization.Domain.Organization", "Organization")
                        .WithMany("OrganizationRoles")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Silky.Organization.Domain.Organization", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("OrganizationPositions");

                    b.Navigation("OrganizationRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
