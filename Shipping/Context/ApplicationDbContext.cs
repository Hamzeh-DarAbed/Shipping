using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shipping.Entities;

namespace Shipping.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ServiceProviderEntity> ServiceProviders { get; set; }
        public DbSet<ShippingService> CarrierServices { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<UserModel> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceProviderEntity>()
                .HasMany(x => x.ShippingService)
                .WithOne(x => x.ServiceProvider)
                .HasForeignKey(x => x.CarrierId);
            
            modelBuilder.Entity<ShippingService>()
                .HasMany(x => x.Packages)
                .WithOne(x => x.ShippingService)
                .HasForeignKey(x => x.ShippingServiceId);

            modelBuilder.Entity<Package>()
                .HasOne(x => x.ShippingService)
                .WithMany(x => x.Packages)
                .HasForeignKey(x => x.ShippingServiceId);

                
            
        }
        
        
    }
}