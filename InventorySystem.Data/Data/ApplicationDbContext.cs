using InventorySystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data.Data;

public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
}