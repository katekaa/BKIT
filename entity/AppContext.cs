using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace entity
{
    class AppContext: DbContext
    {      
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set;}
        public DbSet<DepsEmp> DepsEmps { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Language> Languages { get; set; }

       //private  string connectionString;
        public AppContext()
        {//Database.EnsureDeleted();
           //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // var builder = new ConfigurationBuilder();
           // builder.SetBasePath(Directory.GetCurrentDirectory());
           // builder.AddJsonFile("appsettings.json");
            //var config = builder.Build();
            //connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=entitydb;Trusted_Connection=True;");
        }
       protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().Property(a => a.Firstname).IsRequired();
            modelBuilder.Entity<Employee>().Property(b => b.FullName).HasComputedColumnSql("[Firstname] + ' '+ [Lastname]");
           
        }

    }
}
