using EF_Core_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace EF_Core_Task.Context
{
    public class SchoolBusDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                        .HasOne(driver => driver.Car)
                        .WithOne(car => car.Driver)
                        .HasForeignKey<Driver>(driver => driver.CarId);
        }
    }
}
