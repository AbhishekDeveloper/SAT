using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceAssetTracker.Models;
using ServiceAssetTracker.Models.ResellerViewModels;

namespace ServiceAssetTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reseller> Reseller { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Reseller_Service> Reseller_Service { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase_Order> Purchase_Order { get; set; }
        public DbSet<Job_Reference> Job_Reference { get; set; }
        public DbSet<Job_Service> Job_Service { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<JobReferenceServices> JobReferenceServices { get; set; }
        public DbSet<PoSerial> PoSerials { get; set; }
        public DbSet<ProductServices> ProductServices { get; set; }
        public DbSet<StockType> StockTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
