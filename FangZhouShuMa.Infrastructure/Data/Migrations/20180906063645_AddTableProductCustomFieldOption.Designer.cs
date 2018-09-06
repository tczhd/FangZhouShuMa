﻿// <auto-generated />
using FangZhouShuMa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FangZhouShuMa.Infrastructure.Data.Migrations
{
    [DbContext(typeof(FangZhouShuMaContext))]
    [Migration("20180906063645_AddTableProductCustomFieldOption")]
    partial class AddTableProductCustomFieldOption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountGroupId");

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<string>("CellNumber")
                        .HasMaxLength(30);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CountryId");

                    b.Property<decimal>("CreditLimit");

                    b.Property<int?>("CreditTerms");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(30);

                    b.Property<string>("FaxNumberExt")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("HouseAccount");

                    b.Property<DateTime>("JoinDateUTC");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdatedUTC");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumberExt")
                        .HasMaxLength(20);

                    b.Property<string>("StateName")
                        .HasMaxLength(50);

                    b.Property<bool>("TaxException");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AccountGroupId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.AccountGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SalesChannelId");

                    b.HasKey("Id");

                    b.HasIndex("SalesChannelId");

                    b.ToTable("AccountGroups");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<string>("CellNumber")
                        .HasMaxLength(30);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CountryId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(30);

                    b.Property<string>("FaxNumberExt")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("JoinDateUTC");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdatedUTC");

                    b.Property<string>("Notes")
                        .HasMaxLength(500);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumberExt")
                        .HasMaxLength(20);

                    b.Property<int?>("SalesPersonId");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.SalesChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SalesChannels");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.GenericAggregate.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("FullName")
                        .HasMaxLength(100);

                    b.Property<string>("ISO2")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("ISO3")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<short>("NumCode");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.BillingInfo", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(200);

                    b.Property<int>("CountryId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneExt")
                        .HasMaxLength(50);

                    b.Property<string>("StateName")
                        .HasMaxLength(50);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("BillingInfos");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("AmountPaid");

                    b.Property<int>("BillingInfoId");

                    b.Property<DateTime?>("ConfirmationDate");

                    b.Property<int>("CreatedById");

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerNotes")
                        .HasMaxLength(1000);

                    b.Property<bool>("Deleted");

                    b.Property<int?>("EditedById");

                    b.Property<string>("InternalNotes");

                    b.Property<DateTime>("LastUpdateDateUTC");

                    b.Property<DateTime>("OrderDate");

                    b.Property<decimal>("OrderDiscount");

                    b.Property<int>("OrderStatus");

                    b.Property<decimal>("ShippingDiscount");

                    b.Property<int>("ShippingInfoId");

                    b.Property<decimal>("ShippingSubTotal");

                    b.Property<decimal>("ShippingTaxRate");

                    b.Property<decimal?>("SubTotal");

                    b.Property<decimal?>("TaxTotal");

                    b.Property<decimal?>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EditedById");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Discount");

                    b.Property<decimal>("DiscountTotal");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Quantity");

                    b.Property<decimal>("SubTotal");

                    b.Property<decimal>("TaxRate");

                    b.Property<decimal>("TaxTotal");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProductCustomFieldData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FieldData");

                    b.Property<int>("OrderProductCustomFieldId");

                    b.Property<int>("OrderProductId");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("OrderProductId");

                    b.ToTable("OrderProductCustomFieldDatas");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProductCustomFieldOptionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderProductCustomFieldId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductCustomFieldOptionsId");

                    b.HasKey("Id");

                    b.HasIndex("OrderProductCustomFieldId");

                    b.ToTable("OrderProductCustomFieldOptionDatas");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.ShippingInfo", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Company")
                        .HasMaxLength(200);

                    b.Property<int>("CountryId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsRecipient");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Notes");

                    b.Property<string>("PhoneExt")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("StateName")
                        .HasMaxLength(50);

                    b.Property<string>("StoreName")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ShippingInfos");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(50);

                    b.Property<bool>("Active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(50);

                    b.Property<bool>("Active");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("CreateDateUTC");

                    b.Property<string>("Description");

                    b.Property<int>("GroupId");

                    b.Property<DateTime>("LastUpdateDateUTC");

                    b.Property<decimal>("MinumumQuantity");

                    b.Property<bool>("MultipleMinumumQuantity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PictureUri");

                    b.Property<decimal>("Price");

                    b.Property<string>("SKU")
                        .HasMaxLength(50);

                    b.Property<int>("Sequence");

                    b.Property<bool>("Taxable");

                    b.Property<string>("UPC")
                        .HasMaxLength(250);

                    b.Property<int>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int>("FieldTypeId");

                    b.Property<DateTime>("LastUpdateDateUTC");

                    b.Property<int>("MaxLength");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductCustomFieldGroupId");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ProductCustomFieldGroupId");

                    b.ToTable("ProductCustomFields");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FieldData")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdateDateUtc");

                    b.Property<int>("ProductCustomFieldId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductCustomFieldId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCustomFieldDatas");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductCustomFieldGroups");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("DisplayByRelationship");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentOptionsId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductCustomFieldId");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ProductCustomFieldId");

                    b.ToTable("ProductCustomFieldOption");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldOptionsDisplayByRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductCustomFieldDisplayOptionsId");

                    b.Property<int>("ProductCustomFieldPrimaryOptionsId");

                    b.HasKey("Id");

                    b.HasIndex("ProductCustomFieldDisplayOptionsId");

                    b.HasIndex("ProductCustomFieldPrimaryOptionsId");

                    b.ToTable("ProductCustomFieldOptionsDisplayByRelationships");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.UserAggregate.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.UserAggregate.SiteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("SiteUsers");
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Account", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.AccountGroup", "AccountGroup")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountGroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.AccountGroup", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.SalesChannel", "SalesChannel")
                        .WithMany("AccountGroups")
                        .HasForeignKey("SalesChannelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Customer", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.UserAggregate.AspNetUser", "AspNetUser")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.BillingInfo", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.Order", "Order")
                        .WithMany("BillingInfos")
                        .HasForeignKey("Id")
                        .HasPrincipalKey("BillingInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.Order", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.UserAggregate.SiteUser", "SiteUserCreated")
                        .WithMany("CreatedOrders")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.UserAggregate.SiteUser", "SiteUserEdited")
                        .WithMany("EditOrders")
                        .HasForeignKey("EditedById")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProduct", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProductCustomFieldData", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProduct", "OrderProduct")
                        .WithMany("OrderProductCustomFieldData")
                        .HasForeignKey("OrderProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProductCustomFieldOptionData", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.OrderProductCustomFieldData", "OrderProductCustomFieldData")
                        .WithMany("OrderProductCustomFieldOptionData")
                        .HasForeignKey("OrderProductCustomFieldId")
                        .HasPrincipalKey("OrderProductCustomFieldId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.ShippingInfo", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate.Customer", "Customer")
                        .WithMany("ShippingInfos")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte.Order", "Order")
                        .WithMany("ShippingInfos")
                        .HasForeignKey("Id")
                        .HasPrincipalKey("ShippingInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Group", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Category", "Category")
                        .WithMany("Groups")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Product", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Group", "Group")
                        .WithMany("Products")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomField", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldGroup", "ProductCustomFieldGroup")
                        .WithMany("ProductCustomFields")
                        .HasForeignKey("ProductCustomFieldGroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldData", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomField", "ProductCustomField")
                        .WithMany("ProductCustomFieldData")
                        .HasForeignKey("ProductCustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.Product", "Product")
                        .WithMany("ProductCustomFieldData")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldOption", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomField", "ProductCustomField")
                        .WithMany("ProductCustomFieldOptions")
                        .HasForeignKey("ProductCustomFieldId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldOptionsDisplayByRelationship", b =>
                {
                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldOption", "ProductCustomFieldOptionDisplay")
                        .WithMany("ProductCustomFieldOptionsDisplayByRelationshipDisplays")
                        .HasForeignKey("ProductCustomFieldDisplayOptionsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FangZhouShuMa.ApplicationCore.Entities.ProductAggregate.ProductCustomFieldOption", "ProductCustomFieldOptionPrimary")
                        .WithMany("ProductCustomFieldOptionsDisplayByRelationshipPrimaries")
                        .HasForeignKey("ProductCustomFieldPrimaryOptionsId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
