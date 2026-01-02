using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        //Courses table
        public DbSet<Courses> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
