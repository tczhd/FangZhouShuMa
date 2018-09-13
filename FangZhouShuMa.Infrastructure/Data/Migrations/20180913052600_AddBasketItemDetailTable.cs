using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddBasketItemDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketItemDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasketItemId = table.Column<int>(nullable: false),
                    ProductCustomFieldData = table.Column<string>(nullable: false),
                    ProductCustomFieldDataDescription = table.Column<string>(nullable: false),
                    ProductCustomFieldGroupId = table.Column<int>(nullable: false),
                    ProductCustomFieldGroupName = table.Column<string>(nullable: false),
                    ProductCustomFieldId = table.Column<int>(nullable: false),
                    ProductCustomFieldName = table.Column<string>(nullable: false),
                    ProductCustomFieldOptionId = table.Column<int>(nullable: true),
                    ProductCustomFieldTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItemDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItemDetail_BasketItems_BasketItemId",
                        column: x => x.BasketItemId,
                        principalTable: "BasketItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItemDetail_BasketItemId",
                table: "BasketItemDetail",
                column: "BasketItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItemDetail");
        }
    }
}
