using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

        // Create data -> After that run add-migration + name file gen or update-database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Guid myuuid = Guid.NewGuid();
            Guid myuuid1 = Guid.NewGuid(); // Create another Uuid
            Guid myuuid2 = Guid.NewGuid(); // Create another Uuid
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = myuuid.ToString(),
                DiscountAmount = 10,
                MinAmount = 20000,
                LastUpdated = DateTime.UtcNow,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = myuuid1.ToString(),
                DiscountAmount = 20,
                MinAmount = 50000,
                LastUpdated = DateTime.UtcNow,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = myuuid2.ToString(),
                DiscountAmount = 15,
                MinAmount = 25000,
                LastUpdated = DateTime.UtcNow,
            });
        }
    }
}
