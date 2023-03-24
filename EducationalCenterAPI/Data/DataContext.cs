using EducationalCenterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenterAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(user => new
                {
                    user.Username,
                    user.Email,
                    user.PhoneNumber
                })
                .IsUnique(true);
        }

    }
}
