
using E_LEARNING_SE_102_PROJECT.Data;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Services.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }

            }
            catch 
            {
                throw;
            }
          
        }
    }
}
