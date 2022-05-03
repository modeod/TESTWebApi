using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTDBAccessLib.Models;

namespace TESTDBAccessLib
{
    public class WebApiCoreContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CurrentWeatherModel> Weathers { get; set; }

        public WebApiCoreContext(DbContextOptions<WebApiCoreContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureDeleted(); 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerModel>().HasData(new CustomerModel { Id = 1, Name = "Greg", Birth = DateTimeOffset.Now, Email = "booaabaaa" });
            builder.Entity<CustomerModel>().HasData(new CustomerModel { Id = 2, Name = "Bob", Birth = DateTimeOffset.Now, Email = "sadsaf" });
        }
    }
}
