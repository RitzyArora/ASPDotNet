using JWTAuthenticationWithEFCore.Models;
using Microsoft.EntityFrameworkCore;
namespace JWTAuthenticationWithEFCore.Data

{
    

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }

}
