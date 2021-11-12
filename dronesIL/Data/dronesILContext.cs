using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dronesIL.Models;

namespace dronesIL.Data
{
    public class dronesILContext : DbContext
    {
        public dronesILContext (DbContextOptions<dronesILContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DronesOrders>()
                .HasKey(od => new { od.droneId, od.orderId });

            
        }

        public DbSet<dronesIL.Models.Drone> Drone { get; set; }

        public DbSet<dronesIL.Models.user> user { get; set; }

        public DbSet<dronesIL.Models.Order> Order { get; set; }
        public DbSet<dronesIL.Models.DronesOrders> dronesOrders { get; set; }
    }
}
