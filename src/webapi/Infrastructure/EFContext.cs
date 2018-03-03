using EFMultiThread.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFMultiThread.Infrastructure
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Categories")
                .Property(c => c.Id)
                    .HasColumnName("CategoryId");
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Host>()
                .ToTable("Hosts")
                .HasKey(h => h.Id);
        }
    }
}