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
        public IRepository<AddressModel> AddressRepository { get; set; }
        public IRepository<BathroomModel> BathroomRepository { get; set; }
        public IRepository<BedroomModel> BedroomRepository { get; set; }
        public IRepository<ReviewModel> ReviewRepository { get; set; }
        public IRepository<LocationModel> LocationRepository { get; set; }
        public IRepository<LodgingModel> LodgingRepository { get; set; }
        public IRepository<RentalModel> RentalRepository { get; set; }
        public IRepository<RentalUnitModel> RentalUnitRepository { get; set; }

        /// <summary>
        /// The UnitOfWork constructor, setting an instance of the dbcontext and handing it to the repositories
        /// </summary>
        /// <param name="ldb">The instance of the LodgingDbContext</param>
        public UnitOfWork(LodgingDbContext ldb)
        {
            _ldb = ldb;
            AddressRepository = new Repository<AddressModel>(ldb);
            LocationRepository = new Repository<LocationModel>(ldb);
            ReviewRepository = new Repository<ReviewModel>(ldb);
            BathroomRepository = new Repository<BathroomModel>(ldb);
            BedroomRepository = new Repository<BedroomModel>(ldb);
            LodgingRepository = new Repository<LodgingModel>(ldb);
            RentalRepository = new Repository<RentalModel>(ldb);
            RentalUnitRepository = new Repository<RentalUnitModel>(ldb);
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
