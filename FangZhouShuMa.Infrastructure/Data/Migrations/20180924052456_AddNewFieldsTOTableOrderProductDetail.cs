using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddNewFieldsTOTableOrderProductDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldDataDescription",
                table: "OrderProductCustomFieldDatas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCustomFieldName",
                table: "OrderProductCustomFieldDatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldDataDescription",
                table: "OrderProductCustomFieldDatas");

            migrationBuilder.DropColumn(
                name: "ProductCustomFieldName",
                table: "OrderProductCustomFieldDatas");
        }
    }
}
