using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Buissnessman> Buissnessmen { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Crops> Crops { get; set; }
        public DbSet<Farmers> Farmers { get; set; }
        public DbSet<Orders> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
