using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        NormalizedEmail = table.Column<string>(nullable: true),
            //        NormalizedUserName = table.Column<string>(nullable: true),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        UserName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(maxLength: 50, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    ISO2 = table.Column<string>(maxLength: 2, nullable: false),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    NumCode = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomFieldGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomFieldGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesChannels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbreviation = table.Column<string>(maxLength: 50, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    FieldTypeId = table.Column<int>(nullable: false),
                    LastUpdateDateUTC = table.Column<DateTime>(nullable: false),
                    MaxLength = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductCustomFieldGroupId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomFields_ProductCustomFieldGroups_ProductCustomFieldGroupId",
                        column: x => x.ProductCustomFieldGroupId,
                        principalTable: "ProductCustomFieldGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SalesChannelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountGroups_SalesChannels_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "SalesChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    CreateDateUTC = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    LastUpdateDateUTC = table.Column<DateTime>(nullable: false),
                    MinumumQuantity = table.Column<decimal>(nullable: false),
                    MultipleMinumumQuantity = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SKU = table.Column<string>(maxLength: 50, nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    Taxable = table.Column<bool>(nullable: false),
                    UPC = table.Column<string>(maxLength: 250, nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountGroupId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 350, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    CellNumber = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CreditLimit = table.Column<decimal>(nullable: false),
                    CreditTerms = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    FaxNumber = table.Column<string>(maxLength: 30, nullable: true),
                    FaxNumberExt = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    HouseAccount = table.Column<bool>(nullable: false),
                    JoinDateUTC = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    LastUpdatedUTC = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumberExt = table.Column<string>(maxLength: 20, nullable: true),
                    StateName = table.Column<string>(maxLength: 50, nullable: true),
                    TaxException = table.Column<bool>(nullable: false),
                    Zip = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountGroups_AccountGroupId",
                        column: x => x.AccountGroupId,
                        principalTable: "AccountGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomFieldDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldData = table.Column<string>(nullable: false),
                    LastUpdateDateUtc = table.Column<DateTime>(nullable: false),
                    ProductCustomFieldId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomFieldDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomFieldDatas_ProductCustomFields_ProductCustomFieldId",
                        column: x => x.ProductCustomFieldId,
                        principalTable: "ProductCustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCustomFieldDatas_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomFieldOptionsDisplayByRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCustomFieldDisplayOptionsId = table.Column<int>(nullable: false),
                    ProductCustomFieldPrimaryOptionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomFieldOptionsDisplayByRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldDisplayOptionsId",
                        column: x => x.ProductCustomFieldDisplayOptionsId,
                        principalTable: "ProductCustomFieldOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldOptions_ProductCustomFieldPrimaryOptionsId",
                        column: x => x.ProductCustomFieldPrimaryOptionsId,
                        principalTable: "ProductCustomFieldOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 350, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    CellNumber = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    FaxNumber = table.Column<string>(maxLength: 30, nullable: true),
                    FaxNumberExt = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    JoinDateUTC = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    LastUpdatedUTC = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumberExt = table.Column<string>(maxLength: 20, nullable: true),
                    SalesPersonId = table.Column<int>(nullable: true),
                    StateName = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: false),
                    Zip = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountPaid = table.Column<decimal>(nullable: true),
                    BillingInfoId = table.Column<int>(nullable: false),
                    ConfirmationDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerNotes = table.Column<string>(maxLength: 1000, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    EditedById = table.Column<int>(nullable: true),
                    InternalNotes = table.Column<string>(nullable: true),
                    LastUpdateDateUTC = table.Column<DateTime>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderDiscount = table.Column<decimal>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    ShippingDiscount = table.Column<decimal>(nullable: false),
                    ShippingInfoId = table.Column<int>(nullable: false),
                    ShippingSubTotal = table.Column<decimal>(nullable: false),
                    ShippingTaxRate = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: true),
                    TaxTotal = table.Column<decimal>(nullable: true),
                    Total = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.UniqueConstraint("AK_Orders_BillingInfoId", x => x.BillingInfoId);
                    table.UniqueConstraint("AK_Orders_ShippingInfoId", x => x.ShippingInfoId);
                    table.ForeignKey(
                        name: "FK_Orders_SiteUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_SiteUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discount = table.Column<decimal>(nullable: false),
                    DiscountTotal = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TaxRate = table.Column<decimal>(nullable: false),
                    TaxTotal = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
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

            migrationBuilder.CreateTable(
                name: "OrderProductCustomFieldDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldData = table.Column<string>(nullable: true),
                    OrderProductCustomFieldId = table.Column<int>(nullable: false),
                    OrderProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductCustomFieldDatas", x => x.Id);
                    table.UniqueConstraint("AK_OrderProductCustomFieldDatas_OrderProductCustomFieldId", x => x.OrderProductCustomFieldId);
                    table.ForeignKey(
                        name: "FK_OrderProductCustomFieldDatas_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductCustomFieldOptionDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderProductCustomFieldId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductCustomFieldOptionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductCustomFieldOptionDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldDatas_OrderProductCustomFieldId",
                        column: x => x.OrderProductCustomFieldId,
                        principalTable: "OrderProductCustomFieldDatas",
                        principalColumn: "OrderProductCustomFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroups_SalesChannelId",
                table: "AccountGroups",
                column: "SalesChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountGroupId",
                table: "Accounts",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CategoryId",
                table: "Groups",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductCustomFieldDatas_OrderProductId",
                table: "OrderProductCustomFieldDatas",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductCustomFieldOptionDatas_OrderProductCustomFieldId",
                table: "OrderProductCustomFieldOptionDatas",
                column: "OrderProductCustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EditedById",
                table: "Orders",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldDatas_ProductCustomFieldId",
                table: "ProductCustomFieldDatas",
                column: "ProductCustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldDatas_ProductId",
                table: "ProductCustomFieldDatas",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldDisplayOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldDisplayOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFieldOptionsDisplayByRelationships_ProductCustomFieldPrimaryOptionsId",
                table: "ProductCustomFieldOptionsDisplayByRelationships",
                column: "ProductCustomFieldPrimaryOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomFields_ProductCustomFieldGroupId",
                table: "ProductCustomFields",
                column: "ProductCustomFieldGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInfos_CustomerId",
                table: "ShippingInfos",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingInfos");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "OrderProductCustomFieldOptionDatas");

            migrationBuilder.DropTable(
                name: "ProductCustomFieldDatas");

            migrationBuilder.DropTable(
                name: "ProductCustomFieldOptionsDisplayByRelationships");

            migrationBuilder.DropTable(
                name: "ShippingInfos");

            migrationBuilder.DropTable(
                name: "OrderProductCustomFieldDatas");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCustomFieldOptions");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ProductCustomFields");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductCustomFieldGroups");

            migrationBuilder.DropTable(
                name: "SiteUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AccountGroups");

            migrationBuilder.DropTable(
                name: "SalesChannels");
        }
    }
}
