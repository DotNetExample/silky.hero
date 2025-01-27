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
    [Migration("20220122153514_v1.8")]
    partial class v18
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
                            ConcurrencyStamp = "2a778c61-538b-40da-8c4f-228fa5533ff1",
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
                            ConcurrencyStamp = "16a16784-b089-41f0-8c7c-71be6f77aa22",
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
                            ConcurrencyStamp = "6cfd35cc-ad85-4375-8466-1c23c55c7b46",
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
                            ConcurrencyStamp = "a78b0787-c847-4e18-b595-cbd337b40347",
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
                            ConcurrencyStamp = "2c40a87a-3235-4ed4-b554-98c5819bd785",
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
                            ConcurrencyStamp = "a468f943-78bc-418e-becc-685ec94e06d7",
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

            modelBuilder.Entity("Silky.Organization.Domain.Organization", b =>
                {
                    b.HasOne("Silky.Organization.Domain.Organization", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Silky.Organization.Domain.Organization", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
