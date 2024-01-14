using Microsoft.EntityFrameworkCore;
using Product.API.Models;

namespace Product.API.Data
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext (DbContextOptions<ProductAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Product { get; set; } = default!;
    }
}
