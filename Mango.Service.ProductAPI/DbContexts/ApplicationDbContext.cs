using Mango.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
