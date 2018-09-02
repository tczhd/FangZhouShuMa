
using Microsoft.EntityFrameworkCore;
using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Entities.UserAggregate;

namespace FangZhouShuMa.Infrastructure.Data
{
    public class FangZhouShuMaContext : DbContext
    {
        public FangZhouShuMaContext()
        { }
        public FangZhouShuMaContext(DbContextOptions<FangZhouShuMaContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<SalesChannel> SalesChannels { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AspNetUsers>()
                .HasMany(e => e.Customers)
                .WithOne(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Account>()
                .HasMany(e => e.Customers)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AccountGroup>()
               .HasMany(e => e.Accounts)
               .WithOne(e => e.AccountGroup)
               .HasForeignKey(e => e.AccountGroupId)
               .HasPrincipalKey(e => e.Id)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SalesChannel>()
           .HasMany(e => e.AccountGroups)
           .WithOne(e => e.SalesChannel)
           .HasForeignKey(e => e.SalesChannelId)
           .HasPrincipalKey(e => e.Id)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Customer>()
         .HasMany(e => e.ShippingInfos)
         .WithOne(e => e.Customer)
         .HasForeignKey(e => e.CustomerId)
         .HasPrincipalKey(e => e.Id)
         .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Customer>()
       .HasMany(e => e.Orders)
       .WithOne(e => e.Customer)
       .HasForeignKey(e => e.CustomerId)
       .HasPrincipalKey(e => e.Id)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
       .HasMany(e => e.Groups)
       .WithOne(e => e.Category)
       .HasForeignKey(e => e.CategoryId)
       .HasPrincipalKey(e => e.Id)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Group>()
       .HasMany(e => e.Products)
       .WithOne(e => e.Group)
       .HasForeignKey(e => e.GroupId)
       .HasPrincipalKey(e => e.Id)
       .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ProductCustomFieldGroup>()
       .HasMany(e => e.ProductCustomFields)
       .WithOne(e => e.ProductCustomFieldGroup)
       .HasForeignKey(e => e.ProductCustomFieldGroupId)
       .HasPrincipalKey(e => e.Id)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductCustomField>()
      .HasMany(e => e.ProductCustomFieldOptions)
      .WithOne(e => e.ProductCustomField)
      .HasForeignKey(e => e.ProductCustomFieldId)
      .HasPrincipalKey(e => e.Id)
      .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductCustomFieldOption>()
    .HasMany(e => e.ProductCustomFieldOptionsDisplayByRelationshipPrimaries)
    .WithOne(e => e.ProductCustomFieldOptionPrimary)
    .HasForeignKey(e => e.ProductCustomFieldPrimaryOptionsId)
    .HasPrincipalKey(e => e.Id)
    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductCustomFieldOption>()
.HasMany(e => e.ProductCustomFieldOptionsDisplayByRelationshipDisplays)
.WithOne(e => e.ProductCustomFieldOptionDisplay)
.HasForeignKey(e => e.ProductCustomFieldDisplayOptionsId)
.HasPrincipalKey(e => e.Id)
.OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Order>()
.HasMany(e => e.OrderProducts)
.WithOne(e => e.Order)
.HasForeignKey(e => e.OrderId)
.HasPrincipalKey(e => e.Id)
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
.HasMany(e => e.ShippingInfos)
.WithOne(e => e.Order)
.HasForeignKey(e => e.Id)
.HasPrincipalKey(e => e.ShippingInfoId)
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
.HasMany(e => e.BillingInfos)
.WithOne(e => e.Order)
.HasForeignKey(e => e.Id)
.HasPrincipalKey(e => e.BillingInfoId)
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderProduct>()
.HasMany(e => e.OrderProductCustomFieldData)
.WithOne(e => e.OrderProduct)
.HasForeignKey(e => e.OrderProductId)
.HasPrincipalKey(e => e.Id)
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderProductCustomFieldData>()
.HasMany(e => e.OrderProductCustomFieldOptionData)
.WithOne(e => e.OrderProductCustomFieldData)
.HasForeignKey(e => e.OrderProductCustomFieldId)
.HasPrincipalKey(e => e.OrderProductCustomFieldId)
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SiteUser>()
.HasMany(e => e.CreatedOrders)
.WithOne(e => e.SiteUserCreated)
.HasForeignKey(e => e.CreatedById)
.HasPrincipalKey(e => e.Id)
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SiteUser>()
.HasMany(e => e.EditOrders)
.WithOne(e => e.SiteUserEdited)
.HasForeignKey(e => e.EditedById)
.HasPrincipalKey(e => e.Id)
.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
