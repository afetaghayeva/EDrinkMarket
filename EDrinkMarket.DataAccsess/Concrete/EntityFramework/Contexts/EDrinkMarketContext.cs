using EDrinkMarket.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EDrinkMarket.DataAccess.Concrete.EntityFramework.Contexts
{
    public class EDrinkMarketContext : DbContext
    {
        public EDrinkMarketContext(DbContextOptions<EDrinkMarketContext> options):base(options)
        {
            
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
