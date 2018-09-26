using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddOrderProductCustomFieldDataId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductCustomFieldDataId",
                table: "OrderProductCustomFieldOptionDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDataId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "OrderProductCustomFieldDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                column: "ProductCustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_OrderProductCustomFieldDataId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "OrderProductCustomFieldDataId",
                principalTable: "OrderProductCustomFieldDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_OrderProductCustomFieldDataId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDataId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas");

            migrationBuilder.DropColumn(
                name: "OrderProductCustomFieldDataId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                column: "ProductCustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "ProductCustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "ProductCustomFieldId",
                principalTable: "OrderProductCustomFieldDatas",
                principalColumn: "ProductCustomFieldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
