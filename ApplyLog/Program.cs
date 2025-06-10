using ApplyLog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplyLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            string db = "";
            if(db == "sqllite")
            {
                string DBpath = Path.Combine(Directory.GetCurrentDirectory(), builder.Configuration.GetConnectionString("MeineDatenbank"));
                string connectionString = $"Data Source ={DBpath}";
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseLazyLoadingProxies().UseSqlite(connectionString));
            } 
            else
            {
                string connectionString = builder.Configuration.GetConnectionString("DBSchool");
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            }  

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login"; 
                options.AccessDeniedPath = "/Identity/Account/Register";
            });

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();

                // Add new Roles
                var roleContext = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roleExists = roleContext.RoleExistsAsync("Admin").Result;
                if (!roleExists)
                {
                    var admin = roleContext.CreateAsync(new IdentityRole("Admin"));
                    admin.Wait();
                    var user = roleContext.CreateAsync(new IdentityRole("User"));
                    user.Wait();
                    app.Logger.LogInformation("-> Admin & User Role Created");
                }

                // Admin User
                var userContext = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                IdentityUser adminUser = new IdentityUser();
                adminUser.Email = "admin@admin.de";
                adminUser.UserName = "admin@admin.de";
                string pass = "Test123!";
                var userExists = userContext.FindByEmailAsync(adminUser.Email).Result;
                if (userExists == null)
                {
                    var userCreate = userContext.CreateAsync(adminUser, pass);
                    userCreate.Wait();
                    var addToRole = userContext.AddToRoleAsync(adminUser, "Admin");
                    addToRole.Wait();
                    app.Logger.LogInformation("-> admin@admin.de User Created and added to the Admin Role");
                }

                IdentityUser testUser1 = new IdentityUser();
                testUser1.Email = "tester@tester.de";
                testUser1.UserName = "tester@tester.de";
                string pass1 = "Test123!";
                IdentityUser testUser2 = new IdentityUser();
                testUser2.Email = "test@test.de";
                testUser2.UserName = "test@test.de";
                string pass2 = "Test123!";
                var testUser1Exists = userContext.FindByEmailAsync(testUser1.Email).Result;
                if (testUser1Exists == null)
                {
                    var userCreate = userContext.CreateAsync(testUser1, pass1);
                    userCreate.Wait();
                    var addToRole = userContext.AddToRoleAsync(testUser1, "User");
                    addToRole.Wait();
                    app.Logger.LogInformation("tester@tester.de User Created and added to the User Role");
                    userCreate = userContext.CreateAsync(testUser2, pass2);
                    userCreate.Wait();
                    addToRole = userContext.AddToRoleAsync(testUser2, "User");
                    addToRole.Wait();
                    app.Logger.LogInformation("test@test.de User Created and added to the User Role");
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
