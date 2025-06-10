using ApplyLog.CVModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplyLog.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<TODO> Todos { get; set; }

        public DbSet<Bewerbung> Applications { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<PersonalInfo> Personal { get; set; }

        public DbSet<EducationEntry> Educations { get; set; }

        public DbSet<LanguageEntry> Languages { get; set; }

        public DbSet<WorkEntry> Works { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), "Database.db");
        //    optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");
        //}
    }
}
