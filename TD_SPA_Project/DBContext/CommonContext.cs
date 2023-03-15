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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");
                entity.HasNoKey();

            });
            base.OnModelCreating(modelBuilder);

        }
    }
}

