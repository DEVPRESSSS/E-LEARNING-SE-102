using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        //Courses table
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Contents> Contents { get; set; }
        public DbSet<ApplicationUser> AppUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Courses
            modelBuilder.Entity<Courses>()
                .HasIndex(e => e.Title)
                .IsUnique();

            //Lessons
            modelBuilder.Entity<Lesson>()
              .HasIndex(e => e.Title)
              .IsUnique();

            //Application User
            //modelBuilder.Entity<ApplicationUser>()
            //  .HasIndex(e => new {e.UserName, e.})
            //  .IsUnique();

            base.OnModelCreating(modelBuilder);
            
   
        }
    }
}
