using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using ServiceProvider = Shipping.Entities.ServiceProvider;

namespace Shipping.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<ShippingService> CarrierServices { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceProvider>()
                .HasMany(x => x.ShippingService)
                .WithOne(x => x.ServiceProvider)
                .HasForeignKey(x => x.CarrierId);
            
            modelBuilder.Entity<ShippingService>()
                .HasMany(x => x.Packages)
                .WithOne(x => x.ShippingService)
                .HasForeignKey(x => x.ShippingServiceId);
            
        }
        
        
    }
}