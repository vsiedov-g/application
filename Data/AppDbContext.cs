using System;
using application.Models;
using application.Utility;
using Microsoft.EntityFrameworkCore;

namespace application.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<WorkspaceType> WorkspaceTypes { get; }
        public DbSet<Workspace> Workspaces { get; }
        public DbSet<Booking> Bookings { get; }
        public DbSet<Amenity> Amenities { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkspaceType>().HasData(
                new WorkspaceType { Id = 1, Name = SD.WorkspaceTypes.OpenSpace},
                new WorkspaceType { Id = 2, Name = SD.WorkspaceTypes.PrivateRoom},
                new WorkspaceType { Id = 3, Name = SD.WorkspaceTypes.MeetingRoom}
            );
            builder.Entity<Workspace>().HasData(
                new Workspace { Id = 1, Name = "Desk 1", Capacity = 1, WorkspaceTypeId = 1},
                new Workspace { Id = 2, Name = "Desk 2", Capacity = 1, WorkspaceTypeId = 1},
                new Workspace { Id = 3, Name = "Desk 3", Capacity = 1, WorkspaceTypeId = 1},
                new Workspace { Id = 4, Name = "Desk 4", Capacity = 1, WorkspaceTypeId = 1},
                new Workspace { Id = 5, Name = "Desk 5", Capacity = 1, WorkspaceTypeId = 1},
                new Workspace { Id = 6, Name = "Room 1", Capacity = 1, WorkspaceTypeId = 2},
                new Workspace { Id = 7, Name = "Room 2", Capacity = 1, WorkspaceTypeId = 2},
                new Workspace { Id = 8, Name = "Room 3", Capacity = 2, WorkspaceTypeId = 2},
                new Workspace { Id = 9, Name = "Room 4", Capacity = 5, WorkspaceTypeId = 2},
                new Workspace { Id = 10, Name = "Room 5", Capacity = 10, WorkspaceTypeId = 2}
            );
            builder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = SD.Amenities.WiFi},
                new Amenity { Id = 2, Name = SD.Amenities.Power},
                new Amenity { Id = 3, Name = SD.Amenities.Coffee},
                new Amenity { Id = 4, Name = SD.Amenities.AC}
            );
            builder.Entity<WorkspaceType>()
            .HasMany(w => w.Amenities)
            .WithMany(a => a.WorkspaceTypes)
            .UsingEntity<Dictionary<string, object>>(
            "AmenityWorkspaceType",
            j => j.HasOne<Amenity>().WithMany().HasForeignKey("AmenityId"),
            j => j.HasOne<WorkspaceType>().WithMany().HasForeignKey("WorkspaceTypeId"),
            j =>
            {
                j.HasKey("AmenityId", "WorkspaceTypeId");
                j.HasData(
                    new { AmenityId = 1, WorkspaceTypeId = 1 },
                    new { AmenityId = 2, WorkspaceTypeId = 1 },
                    new { AmenityId = 3, WorkspaceTypeId = 1 },
                    new { AmenityId = 1, WorkspaceTypeId = 2 },
                    new { AmenityId = 3, WorkspaceTypeId = 2 },
                    new { AmenityId = 4, WorkspaceTypeId = 2 }
                );
            });
            }

    }
}
