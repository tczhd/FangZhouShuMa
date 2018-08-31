using FangZhouShuMa.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FangZhouShuMa.DataAccess
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AspNetUsers>()
                .HasMany(e => e.Customers)
                .WithOne(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
