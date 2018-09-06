using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddDescriptionAndRemoveProductCustomFieldOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropTable(
                name: "ProductCustomFieldOptions");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductCustomFields",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductCustomFields");

            migrationBuilder.CreateTable(
                name: "ProductCustomFieldOptions",
                columns: table => new
                {
                    ProductCustomFieldId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DisplayByRelationship = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentOptionsId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomFieldOptions", x => x.ProductCustomFieldId);
                    table.UniqueConstraint("AK_ProductCustomFieldOptions_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomFieldOptions_ProductCustomFields_ProductCustomFieldId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldDisplayOptionsId",
                principalTable: "ProductCustomFieldOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldPrimaryOptionsId",
                principalTable: "ProductCustomFieldOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
