using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TmsId.Api.Models;
using TmsId.Api.Models;

namespace TmsId.Api.Models
{
    public interface ITmsDbContext
    {
        DbSet<Driver> Drivers { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Truck> Trucks { get; set; }
    }

    public class TmsDbContext : IdentityDbContext, ITmsDbContext
    {
        public TmsDbContext(DbContextOptions<TmsDbContext> options):base(options)
        {
                
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Truck> Trucks { get; set; } 
    }
}
