using Microsoft.EntityFrameworkCore;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Database
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) :
            base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseCollation("Cyrillic_General_CI_AS");
            builder.Entity<OrderDetail>().HasKey(table => new
            {
                table.OrderId,
                table.GoodId
            });
            builder.Entity<DrugSubstance>().HasKey(table => new
            {
                table.DrugId,
                table.SubstanceId
            });
        }

        public DbSet<Substance> Substance { get; set; }
        public DbSet<Drug> Drug { get; set; }
        public DbSet<MedicalForm> MedicalForm { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Good> Good { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }

        public DbSet<DrugPackaging> DrugPackaging { get; set; }
        public DbSet<DrugSubstance> DrugSubstance { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }

        public DbSet<DeliveryCompany> DeliveryCompany { get; set; }


    }
}
