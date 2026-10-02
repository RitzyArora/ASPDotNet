using Microsoft.EntityFrameworkCore;
using DemoOfEfCore.Models;

namespace DemoOfEfCore.Data
{
    
    namespace EFCoreMVC.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
        }
    }

}
