using BCrypt.Net;
using RoleBasedAuthWithJWT.Models;
namespace RoleBasedAuthWithJWT.Data
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;
        public DataSeeder(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Seed()
        {
            if (!_context.Roles.Any())
            {
                var adminRole = new Role { Name = "Admin" };
                var userRole = new Role { Name = "User" };
                _context.Roles.AddRange(adminRole,userRole);
                _context.SaveChanges();
            }

            if (!_context.Users.Any())
            {
                var adminUser = new User { Username="admin",Password=BCrypt.Net.BCrypt.HashPassword("admin123") };
                
                _context.Users.Add(adminUser);
                _context.SaveChanges();
                var adminUserRole = new UserRole
                {
                    UserId = adminUser.Id,
                    RoleId = _context.Roles.First(r => r.Name == "admin").Id,
                };
                _context.UserRoles.Add(adminUserRole);
                _context.SaveChanges();
            
            }

            


        }
    }
}