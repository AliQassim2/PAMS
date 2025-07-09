using Microsoft.EntityFrameworkCore;

using PAMS.Models;

namespace PAMS.environment
{
    public class AppDbContext : DbContext
    {
        public DbSet<BeneficiaryModel> Beneficiaries { get; set; }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DB.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: configure table names, relationships, etc., if needed
        }
    }
}


