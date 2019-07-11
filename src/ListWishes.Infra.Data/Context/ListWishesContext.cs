using ListWishes.Domain.Entities;
using ListWishes.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ListWishes.Infra.Data.Context
{
    public class ListWishesContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public ListWishesContext(IHostingEnvironment env)
        {
            _env = env;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<User> Products { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<ItemsProductWish> ItemsProductWishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Wish>(new WishMap().Configure);
            modelBuilder.Entity<ItemsProductWish>(new ItemsProductWishMap().Configure);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
