using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TD_SPA_Project.Entity;

namespace TD_SPA_Project.DBContext
{
	public class CommonContext : DbContext
    {
        public CommonContext(DbContextOptions<CommonContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");
                entity.HasKey("iduser");

            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");
                entity.HasKey("idemployee");

            });
            base.OnModelCreating(modelBuilder);

        }
    }
}

