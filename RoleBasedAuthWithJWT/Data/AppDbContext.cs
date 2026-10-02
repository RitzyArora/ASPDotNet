using Microsoft.EntityFrameworkCore;
using RoleBasedAuthWithJWT.Models;
namespace RoleBasedAuthWithJWT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(userRole => new {userRole.UserId, userRole.RoleId});

            modelBuilder.Entity<UserRole>().HasOne(ur => ur.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(userRole => userRole.UserId);

            modelBuilder.Entity<UserRole>().HasOne(ur => ur.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(userRole => userRole.RoleId);

            base.OnModelCreating(modelBuilder);





        }
    }
}
