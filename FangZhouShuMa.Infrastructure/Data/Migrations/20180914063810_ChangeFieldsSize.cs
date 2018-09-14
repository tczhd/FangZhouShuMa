using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class ChangeFieldsSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldName",
                table: "BasketItemDetail",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldGroupName",
                table: "BasketItemDetail",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldDataDescription",
                table: "BasketItemDetail",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldData",
                table: "BasketItemDetail",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_BasketItemDetail_ProductCustomFieldGroupId",
                table: "BasketItemDetail",
                column: "ProductCustomFieldGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItemDetail_ProductCustomFieldId",
                table: "BasketItemDetail",
                column: "ProductCustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItemDetail_ProductCustomFieldGroups_ProductCustomFieldGroupId",
                table: "BasketItemDetail",
                column: "ProductCustomFieldGroupId",
                principalTable: "ProductCustomFieldGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItemDetail_ProductCustomFields_ProductCustomFieldId",
                table: "BasketItemDetail",
                column: "ProductCustomFieldId",
                principalTable: "ProductCustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItemDetail_ProductCustomFieldGroups_ProductCustomFieldGroupId",
                table: "BasketItemDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItemDetail_ProductCustomFields_ProductCustomFieldId",
                table: "BasketItemDetail");

            migrationBuilder.DropIndex(
                name: "IX_BasketItemDetail_ProductCustomFieldGroupId",
                table: "BasketItemDetail");

            migrationBuilder.DropIndex(
                name: "IX_BasketItemDetail_ProductCustomFieldId",
                table: "BasketItemDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldName",
                table: "BasketItemDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldGroupName",
                table: "BasketItemDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldDataDescription",
                table: "BasketItemDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCustomFieldData",
                table: "BasketItemDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
