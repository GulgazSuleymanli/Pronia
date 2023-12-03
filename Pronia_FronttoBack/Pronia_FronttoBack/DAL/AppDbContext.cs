
namespace Pronia_FronttoBack.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
       
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Shipping> Shippers { get; set; }
        public DbSet<Setting> Settings { get; set; }

    }
}
