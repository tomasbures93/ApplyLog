using Microsoft.EntityFrameworkCore;

namespace ApplyLog.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<TODO> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Database.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
