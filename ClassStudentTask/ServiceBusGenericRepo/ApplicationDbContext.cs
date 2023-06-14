using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceBusApp.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Data
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                        .HasMany(c => c.Students)
                        .WithOne(s => s.Class)
                        .HasForeignKey(s => s.ClassId);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

    }
}
