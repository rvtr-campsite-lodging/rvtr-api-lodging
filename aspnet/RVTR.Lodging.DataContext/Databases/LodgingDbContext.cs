using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.DataContext.Databases
{
    public class LodgingDbContext : DbContext
    {
        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<AmenityModel> Amenities { get; set; }
        public DbSet<BedModel> Beds { get; set; }

        public LodgingDbContext(DbContextOptions<LodgingDbContext> builder) : base(builder){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HotelModel>().HasKey(h => h.HotelId);
            builder.Entity<RoomModel>().HasKey(r => r.RoomId);
            builder.Entity<RoomTypeModel>().HasKey(rt => rt.RoomTypeId);
            builder.Entity<ImageModel>().HasKey(i => i.ImageId);
            builder.Entity<ReviewModel>().HasKey(r => r.ReviewId);
            builder.Entity<LocationModel>().HasKey(l => l.LocationId);
            builder.Entity<AmenityModel>().HasKey(a => a.AmenityId);
            builder.Entity<BedModel>().HasKey(b => b.BedId);

            builder.Entity<HotelModel>().HasMany(h => h.Rooms).WithOne();
            builder.Entity<HotelModel>().HasMany(h => h.Images).WithOne();
            builder.Entity<HotelModel>().HasMany(h => h.Amenities).WithOne();
            builder.Entity<HotelModel>().HasMany(h => h.Reviews).WithOne(r => r.Hotel);

            builder.Entity<RoomTypeModel>().HasMany(rt => rt.Images).WithOne();
            builder.Entity<RoomTypeModel>().HasMany(rt => rt.Beds).WithOne();

            builder.Entity<RoomModel>().HasOne(r => r.Type).WithMany();
            builder.Entity<HotelModel>().HasOne(h => h.Location).WithOne().HasForeignKey<HotelModel>();
        }
    }
}
