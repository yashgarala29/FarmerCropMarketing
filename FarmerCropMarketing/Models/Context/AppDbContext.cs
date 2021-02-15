using FarmerCropMarketing.Models.Class;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Crops> Crops { get; set; }
        public DbSet<Farmers> Farmers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<MSPSellCrops>  MSPSellCrops{ get; set; }
        public DbSet<MSPCropsDetail> MSPCropsDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
