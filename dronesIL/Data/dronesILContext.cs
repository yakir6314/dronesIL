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

        public DbSet<dronesIL.Models.Drone> Drone { get; set; }

        public DbSet<dronesIL.Models.User> User { get; set; }
    }
}
