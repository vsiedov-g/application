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
                    Description = "Modern coworking in the heart of Pechersk with quiet rooms and coffee on tap",
                    Address = "123 Yaroslav Val St, Kyiv",
                    ImageUrl = "https://www.mindspace.me/wp-content/uploads/2023/08/Screenshot-2023-08-17-at-08.57.35.png"
                },
                new Coworking
                {
                    Id = 2,
                    Name = "UrbanSpace Podil",
                    Description = "A creative riverside hub ideal for freelancers and small startups",
                    Address = "78 Naberezhno-Khreshachatytska ST, Kyiv",
                    ImageUrl = "https://mlgucbjxeu1m.i.optimole.com/cb:B7VA.3e989/w:1024/h:682/q:mauto/ig:avif/f:best/https://flydesk.com/wp-content/uploads/2021/01/lavaca-barcelona-coworking.jpg"
                },
                new Coworking
                {
                    Id = 3,
                    Name = "Creative Hub Lvivska",
                    Description = "A compact, desight-focused space with open desks and strong community vibes",
                    Address = "12 Lvivska Square,Kyiv",
                    ImageUrl = "https://www.servcorp.com.au/media/31088/socialising-in-a-coworking-space.jpg"
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
                },
                new WorkspaceType
                {
                    Id = 3,
                    Name = SD.WorkspaceTypes.MeetingRoom,
                    CoworkingId = 1,
                    ImageUrl = "https://www.appliedglobal.com/wp-content/uploads/How-to-Create-a-Modern-Meeting-Room-Setup.png",
                    Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs"
                },
                new WorkspaceType
                {
                    Id = 4,
                    Name = SD.WorkspaceTypes.OpenSpace,
                    CoworkingId = 2,
                    ImageUrl = "/images/open-space/openSpace.jpg",
                    Description = "A vibrant shared are perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease"
                },
                new WorkspaceType
                {
                    Id = 5,
                    Name = SD.WorkspaceTypes.PrivateRoom,
                    CoworkingId = 2,
                    ImageUrl = "/images/private-room/privateRoom.jpg",
                    Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs"
                },
                new WorkspaceType
                {
                    Id = 6,
                    Name = SD.WorkspaceTypes.MeetingRoom,
                    CoworkingId = 2,
                    ImageUrl = "https://www.appliedglobal.com/wp-content/uploads/How-to-Create-a-Modern-Meeting-Room-Setup.png",
                    Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed room offer privacy and come in a variety of sizes to fit your needs"
                }
            );
            builder.Entity<Workspace>().HasData(
                new Workspace { Id = 1, Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 2, Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 3, Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 4, Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 5, Capacity = 1, WorkspaceTypeId = 1 },
                new Workspace { Id = 6, Capacity = 1, WorkspaceTypeId = 2 },
                new Workspace { Id = 7, Capacity = 1, WorkspaceTypeId = 2 },
                new Workspace { Id = 8, Capacity = 2, WorkspaceTypeId = 2 },
                new Workspace { Id = 9, Capacity = 5, WorkspaceTypeId = 2 },
                new Workspace { Id = 10, Capacity = 10, WorkspaceTypeId = 2 },
                new Workspace { Id = 11, Capacity = 1, WorkspaceTypeId = 3 },

                new Workspace { Id = 12, Capacity = 1, WorkspaceTypeId = 4 },
                new Workspace { Id = 13, Capacity = 1, WorkspaceTypeId = 4 },
                new Workspace { Id = 14, Capacity = 1, WorkspaceTypeId = 4 },
                new Workspace { Id = 15, Capacity = 1, WorkspaceTypeId = 4 },
                new Workspace { Id = 16, Capacity = 1, WorkspaceTypeId = 5 },
                new Workspace { Id = 17, Capacity = 2, WorkspaceTypeId = 5 },
                new Workspace { Id = 18, Capacity = 2, WorkspaceTypeId = 5 },
                new Workspace { Id = 19, Capacity = 5, WorkspaceTypeId = 5 },
                new Workspace { Id = 20, Capacity = 5, WorkspaceTypeId = 5 },
                new Workspace { Id = 21, Capacity = 10, WorkspaceTypeId = 6 },
                new Workspace { Id = 22, Capacity = 20, WorkspaceTypeId = 6 }
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
