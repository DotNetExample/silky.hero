using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silky.Position.Database.Migrations.Migrations
{
    public partial class v19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Positions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PositionOrganizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PositionId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionOrganizations_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "6d865228-5452-4db9-87ac-d7c3e0712493");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "caaea170-3c83-40bd-99a8-c3dfd82bfd78");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "53e5e358-138c-43ab-b0ba-e5e7fdabdbae");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ConcurrencyStamp",
                value: "bd2828d2-d762-450f-9978-8c52f0f97909");

            migrationBuilder.CreateIndex(
                name: "IX_PositionOrganizations_PositionId",
                table: "PositionOrganizations",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionOrganizations");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Positions");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "736ee5e8-18af-4e01-861e-4adadae13525");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "1b24a1a4-b091-4f66-8e15-af74dfecd4d5");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "d5d75344-4e00-4329-a580-14bee0c90b75");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ConcurrencyStamp",
                value: "3919966e-faff-46a6-864b-9358c0288e7d");
        }
    }
}
