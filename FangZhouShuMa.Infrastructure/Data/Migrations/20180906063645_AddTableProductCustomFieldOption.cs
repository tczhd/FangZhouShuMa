using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddTableProductCustomFieldOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCustomFieldOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    DisplayByRelationship = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentOptionsId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ProductCustomFieldId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomFieldOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomFieldOption_ProductCustomFields_ProductCustomFieldId",
                        column: x => x.ProductCustomFieldId,
                        principalTable: "ProductCustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldDisplayOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldPrimaryOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldOption_ProductCustomFieldId",
                table: "ProductCustomFieldOption",
                column: "ProductCustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOption_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldDisplayOptionsId",
                principalTable: "ProductCustomFieldOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOption_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldPrimaryOptionsId",
                principalTable: "ProductCustomFieldOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOption_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOption_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropTable(
                name: "ProductCustomFieldOption");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");
        }
    }
}
