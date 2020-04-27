using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.DataContext.Databases
{
    public class LodgingDbContext : DbContext
    {
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<BathroomModel> Bathrooms { get; set; }
        public DbSet<BedroomModel> Bedrooms { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<LodgingModel> Lodgings { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<RentalUnitModel> RoomTypes { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }



        public LodgingDbContext(DbContextOptions<LodgingDbContext> builder) : base(builder) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LodgingModel>().HasKey(g => g.Id);
            builder.Entity<BathroomModel>().HasKey(b => b.Id);
            builder.Entity<BedroomModel>().HasKey(d => d.Id);
            builder.Entity<LocationModel>().HasKey(c => c.Id);
            builder.Entity<LodgingModel>().HasKey(l => l.Id);
            builder.Entity<RentalModel>().HasKey(r =>r.Id);
            builder.Entity<RentalUnitModel>().HasKey(r =>r.Id);
            builder.Entity<ReviewModel>().HasKey(r =>r.Id);
            builder.Entity<ImageModel>().HasKey(i =>i.Id);



            builder.Entity<LodgingModel>().HasMany(h => h.Rentals).WithOne();
            builder.Entity<LodgingModel>().HasMany(h => h.Reviews).WithOne();
            builder.Entity<LodgingModel>().HasMany(h => h.Images).WithOne();
            builder.Entity<LodgingModel>().HasOne(h => h.Location).WithOne().HasForeignKey<LodgingModel>();

            builder.Entity<RentalUnitModel>().HasMany(rt => rt.Bedrooms).WithOne();
            builder.Entity<RentalUnitModel>().HasMany(rt => rt.Bathrooms).WithOne();

            builder.Entity<RentalModel>().HasOne(r => r.RentalUnit).WithOne().HasForeignKey<RentalModel>();
            builder.Entity<RentalModel>().HasMany(r => r.Images).WithOne();

            builder.Entity<LocationModel>().HasOne(l => l.Address).WithOne().HasForeignKey<LocationModel>();
        }
    }

}
