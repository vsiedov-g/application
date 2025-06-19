using System;
using application.Models;
using application.Utility;
using Microsoft.EntityFrameworkCore;

namespace application.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Coworking> Coworkings { get; } = null!;
        public DbSet<WorkspaceType> WorkspaceTypes { get; } = null!;
        public DbSet<Workspace> Workspaces { get; } = null!;
        public DbSet<Booking> Bookings { get; } = null!; 
        public DbSet<Amenity> Amenities { get; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Coworking>().HasData(
                new Coworking
                {
                    Id = 1,
                    Name = "WorkClub Perchersk",
                    Address = "123 Yaroslav Val St,Kyiv"
                }
            );

            builder.Entity<WorkspaceType>().HasData(
                new WorkspaceType
                {
                    Id = 1,
                    Name = SD.WorkspaceTypes.OpenSpace,
                    CoworkingId = 1,
                    ImageUrl = "/images/open-space/openSpace.jpg",
                    Description = "A vibrant shared are perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease"
                },
                new WorkspaceType
                {
                    Id = 2,
                    Name = SD.WorkspaceTypes.PrivateRoom,
                    CoworkingId = 1,
                    ImageUrl = "/images/private-room/privateRoom.jpg",
                    Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs"
                }
            );
            builder.Entity<Workspace>().HasData(
                new Workspace { Id = 1, Name = "Desk 1", Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 2, Name = "Desk 2", Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 3, Name = "Desk 3", Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 4, Name = "Desk 4", Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 5, Name = "Desk 5", Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 6, Name = "Room 1", Capacity = 1, WorkspaceTypeId = 2 },
                new Workspace { Id = 7, Name = "Room 2", Capacity = 1, WorkspaceTypeId = 2 },
                new Workspace { Id = 8, Name = "Room 3", Capacity = 2, WorkspaceTypeId = 2 },
                new Workspace { Id = 9, Name = "Room 4", Capacity = 5, WorkspaceTypeId = 2 },
                new Workspace { Id = 10, Name = "Room 5", Capacity = 10, WorkspaceTypeId = 2 }
            );
            builder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = SD.Amenities.WiFi },
                new Amenity { Id = 2, Name = SD.Amenities.Power },
                new Amenity { Id = 3, Name = SD.Amenities.Coffee },
                new Amenity { Id = 4, Name = SD.Amenities.AC }
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
