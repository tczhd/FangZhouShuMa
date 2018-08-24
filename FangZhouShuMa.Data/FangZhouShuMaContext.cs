using FangZhouShuMa.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FangZhouShuMa.Data
{
    public class FangZhouShuMaContext : DbContext
    {
        public FangZhouShuMaContext()
        { }
        public FangZhouShuMaContext(DbContextOptions<FangZhouShuMaContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Slot> Slot { get; set; }
    }
}
