using System;
using RVTR.Lodging.DataContext.Databases;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.DataContext.Repositories
{
  /// <summary>
  /// UnitOfWork combines all repositories
  /// </summary>
  public class UnitOfWork : IUnitOfWork
  {
    private readonly LodgingDbContext _ldb;
    public Repository<HotelModel> Hotels { get; set; }
    public Repository<RoomModel> Rooms { get; set; }
    public Repository<RoomTypeModel> RoomTypes { get; set; }
    public Repository<ImageModel> Images { get; set; }
    public Repository<ReviewModel> Reviews { get; set; }
    public Repository<LocationModel> Locations { get; set; }
    public Repository<AmenityModel> Amenities { get; set; }
    public Repository<BedModel> Beds { get; set; }

    /// <summary>
    /// The UnitOfWork constructor, setting an instance of the dbcontext and handing it to the repositories
    /// </summary>
    /// <param name="ldb">The instance of the LodgingDbContext</param>
    public UnitOfWork(LodgingDbContext ldb)
    {
      _ldb = ldb;
      Hotels = new Repository<HotelModel>(ldb);
      Rooms = new Repository<RoomModel>(ldb);
      RoomTypes = new Repository<RoomTypeModel>(ldb);
      Images = new Repository<ImageModel>(ldb);
      Reviews = new Repository<ReviewModel>(ldb);
      Locations = new Repository<LocationModel>(ldb);
      Amenities = new Repository<AmenityModel>(ldb);
      Beds = new Repository<BedModel>(ldb);
    }

    /// <summary>
    ///Commits all changes to the database
    /// </summary>
    public void Commit()
    {
      _ldb.SaveChanges();
    }
  }
}
