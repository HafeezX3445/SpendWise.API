using Microsoft.EntityFrameworkCore;
using SpendWise.API.Models;
using System;

namespace SpendWise.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply default values for audit properties (CreatedOn and IsActive)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditTable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedOn")
                        .HasDefaultValueSql("GETDATE()");

                    modelBuilder.Entity(entityType.ClrType).Property<bool>("IsActive")
                        .HasDefaultValue(true);
                }
            }

            // Seed data for the Users table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Hafeez",
                    Email = "hafeezshaik245@gmail.com",
                    PasswordHash = "Hafeezshaik@245",
                    CreatedBy = "App Owner",
                    CreatedOn = new DateTime(2025, 4, 30, 11, 30, 0),
                    IsActive = true,
                    Role = "Admin"
                }
            );
        }
    }
}
