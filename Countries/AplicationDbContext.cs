using Countries.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Countries
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryActivity>()
                .HasKey(x => new { x.CountryId,x.ActivityId});

            base.OnModelCreating(modelBuilder);
        }

        //Creando las tablas
        public DbSet<Country> Countries { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<CountryActivity> CountryActivities { get; set; }
    }
}
