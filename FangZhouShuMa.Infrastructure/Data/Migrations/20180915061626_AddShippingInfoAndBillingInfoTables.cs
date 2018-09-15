using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class AddShippingInfoAndBillingInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneExt = table.Column<string>(maxLength: 50, nullable: true),
                    StateName = table.Column<string>(maxLength: 50, nullable: true),
                    Zip = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Company = table.Column<string>(maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    PhoneExt = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ShippingMethodId = table.Column<int>(nullable: false),
                    StateName = table.Column<string>(maxLength: 50, nullable: true),
                    StoreName = table.Column<string>(maxLength: 200, nullable: true),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Zip = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingInfos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingInfoId",
                table: "Orders",
                column: "BillingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInfos_OrderId",
                table: "ShippingInfos",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BillingInfos_BillingInfoId",
                table: "Orders",
                column: "BillingInfoId",
                principalTable: "BillingInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BillingInfos_BillingInfoId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BillingInfos");

            migrationBuilder.DropTable(
                name: "ShippingInfos");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingInfoId",
                table: "Orders");
        }
    }
}
