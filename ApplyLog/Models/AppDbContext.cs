using Microsoft.EntityFrameworkCore;

namespace ApplyLog.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TODO> Todos { get; set; }
        public DbSet<Bewerbung> Applications { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), "Database.db");
        //    optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
        //}
    }
}
