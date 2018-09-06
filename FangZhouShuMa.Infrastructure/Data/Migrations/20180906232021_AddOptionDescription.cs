using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddOptionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOption_ProductCustomFields_ProductCustomFieldId",
                table: "ProductCustomFieldOption");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOption_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOption_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCustomFieldOption",
                table: "ProductCustomFieldOption");

            migrationBuilder.RenameTable(
                name: "ProductCustomFieldOption",
                newName: "ProductCustomFieldOptions");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCustomFieldOption_ProductCustomFieldId",
                table: "ProductCustomFieldOptions",
                newName: "IX_ProductCustomFieldOptions_ProductCustomFieldId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductCustomFieldOptions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCustomFieldOptions",
                table: "ProductCustomFieldOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomFieldOptions_ProductCustomFields_ProductCustomFieldId",
                table: "ProductCustomFieldOptions",
                column: "ProductCustomFieldId",
                principalTable: "ProductCustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptions_ProductCustomFields_ProductCustomFieldId",
                table: "ProductCustomFieldOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCustomFieldOptions",
                table: "ProductCustomFieldOptions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductCustomFieldOptions");

            migrationBuilder.RenameTable(
                name: "ProductCustomFieldOptions",
                newName: "ProductCustomFieldOption");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCustomFieldOptions_ProductCustomFieldId",
                table: "ProductCustomFieldOption",
                newName: "IX_ProductCustomFieldOption_ProductCustomFieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCustomFieldOption",
                table: "ProductCustomFieldOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomFieldOption_ProductCustomFields_ProductCustomFieldId",
                table: "ProductCustomFieldOption",
                column: "ProductCustomFieldId",
                principalTable: "ProductCustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
