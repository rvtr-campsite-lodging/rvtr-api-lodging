using System.Collections.Generic;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.DataContext.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<AddressModel> AddressRepository { get; }
        IRepository<LocationModel> LocationRepository{ get; }
        IRepository<ReviewModel> ReviewRepository { get; }
        IRepository<BathroomModel> BathroomRepository { get; }
        IRepository<BedroomModel> BedroomRepository { get; }
        IRepository<LodgingModel> LodgingRepository { get; }
        IRepository<RentalModel> RentalRepository { get; }
        IRepository<RentalUnitModel> RentalUnitRepository { get; }
        void Commit();
    }
}
