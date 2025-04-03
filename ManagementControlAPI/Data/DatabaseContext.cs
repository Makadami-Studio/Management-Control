using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagementControlAPI.Models;

namespace ManagementControlAPI.Data
{
      public class DatabaseContext : DbContext
      {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

            // DbSets for each model
            public DbSet<User> Users { get; set; }
            public DbSet<Flat> Flats { get; set; }
            public DbSet<Tasks> Tasks { get; set; }
            public DbSet<ShoppingRequest> ShoppingRequests { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);

                  // Flat <-> Users (many-to-many)
                  modelBuilder.Entity<Flat>()
                        .HasMany(f => f.Users)
                        .WithMany();

                  // Flat -> Owner (one-to-many)
                  modelBuilder.Entity<Flat>()
                        .HasOne(f => f.Owner)
                        .WithMany()
                        .HasForeignKey(f => f.OwnerId)
                        .OnDelete(DeleteBehavior.Restrict);

                  // Flat -> Tasks (one-to-many)
                  modelBuilder.Entity<Flat>()
                        .HasMany(f => f.Tasks)
                        .WithOne(t => t.AssignedFlat)
                        .HasForeignKey(t => t.AssignedFlatId);

                  // Tasks -> AssignedTo (one-to-many)
                  modelBuilder.Entity<Tasks>()
                        .HasOne(t => t.AssignedTo)
                        .WithMany()
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Restrict);

                  // Tasks -> CreatedBy
                  modelBuilder.Entity<Tasks>()
                        .HasOne(t => t.CreatedBy)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                  // Tasks -> UpdatedBy
                  modelBuilder.Entity<Tasks>()
                        .HasOne(t => t.UpdatedBy)
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                  // ShoppingRequest -> Flat (one-to-many)
                  modelBuilder.Entity<ShoppingRequest>()
                        .HasOne<Flat>() // lub .HasOne(sr => sr.Flat)
                        .WithMany()
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade);
            }
      }
}