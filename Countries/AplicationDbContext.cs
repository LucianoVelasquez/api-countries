using Countries.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Countries
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Creando las tablas
        public DbSet<Country> Countries { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
