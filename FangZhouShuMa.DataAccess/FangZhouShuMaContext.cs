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

        public virtual DbSet<Slot> Slot { get; set; }
    }
}
