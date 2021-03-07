using ZupBank.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ZupBank.Data.Data.Connectors
{
    public class PerContext : DbContext
    {
        public PerContext(DbContextOptions<PerContext> options) : base(options)
        {
        }

        public DbSet<PersonModel> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
