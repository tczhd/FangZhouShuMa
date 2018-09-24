using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddForeginKeyOrderProductCustomFieldData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductCustomFieldDatas_ProductCustomFields_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                column: "ProductCustomFieldId",
                principalTable: "ProductCustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductCustomFieldDatas_ProductCustomFields_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas");
        }
    }
}
