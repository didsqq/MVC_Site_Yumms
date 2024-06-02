using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Yumms.Models
{
    public class YummsContext : DbContext
    {
        public YummsContext() : base("YummsContext") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Type> Product_Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}