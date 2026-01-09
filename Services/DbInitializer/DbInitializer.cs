
using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using E_LEARNING_SE_102_PROJECT.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Services.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext context,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }

            if (!_roleManager.RoleExistsAsync(SD.Learner).GetAwaiter().GetResult())
            {
                // Create Roles
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Learner)).GetAwaiter().GetResult();

                // Create Admin User
                var user = new ApplicationUser
                {
                    UserName = "xmontemorjerald@gmail.com",
                    Email = "xmontemorjerald@gmail.com",
                    FirstName = "Jerald",
                    MiddleName = "Rabino",
                    LastName = "Montemor",
                    PhoneNumber = "09789449801",
                    EmailConfirmed = true
                };

                _userManager.CreateAsync(user, "Admin123*").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, SD.Admin).GetAwaiter().GetResult();
            }

        }
    }
}
