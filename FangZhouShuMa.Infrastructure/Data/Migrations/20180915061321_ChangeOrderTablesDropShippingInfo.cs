using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class ChangeOrderTablesDropShippingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_OrderProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropTable(
                name: "BillingInfos");

            migrationBuilder.DropTable(
                name: "ShippingInfos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Orders_BillingInfoId",
                table: "Orders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Orders_ShippingInfoId",
                table: "Orders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderProductCustomFieldDatas_OrderProductCustomFieldId",
                table: "OrderProductCustomFieldDatas");

            migrationBuilder.DropColumn(
                name: "ShippingInfoId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                newName: "ProductCustomFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                newName: "IX_OrderProductCustomFieldOptionDatas_ProductCustomFieldId");

            migrationBuilder.RenameColumn(
                name: "OrderProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                newName: "ProductCustomFieldId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                column: "ProductCustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "ProductCustomFieldId",
                principalTable: "OrderProductCustomFieldDatas",
                principalColumn: "ProductCustomFieldId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderProductCustomFieldDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas");

            migrationBuilder.RenameColumn(
                name: "ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                newName: "OrderProductCustomFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_ProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                newName: "IX_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldId");

            migrationBuilder.RenameColumn(
                name: "ProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                newName: "OrderProductCustomFieldId");

            migrationBuilder.AddColumn<int>(
                name: "ShippingInfoId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Orders_BillingInfoId",
                table: "Orders",
                column: "BillingInfoId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Orders_ShippingInfoId",
                table: "Orders",
                column: "ShippingInfoId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderProductCustomFieldDatas_OrderProductCustomFieldId",
                table: "OrderProductCustomFieldDatas",
                column: "OrderProductCustomFieldId");

            migrationBuilder.CreateTable(
                name: "BillingInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_BillingInfos_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "BillingInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Company = table.Column<string>(maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    IsRecipient = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PhoneExt = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    StateName = table.Column<string>(maxLength: 50, nullable: true),
                    StoreName = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Zip = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingInfos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingInfos_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "ShippingInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInfos_CustomerId",
                table: "ShippingInfos",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_OrderProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "OrderProductCustomFieldId",
                principalTable: "OrderProductCustomFieldDatas",
                principalColumn: "OrderProductCustomFieldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
