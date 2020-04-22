using System.Collections.Generic;

namespace RVTR.Lodging.DataContext.Repositories
{
  public interface IUnitOfWork
  {
    void Commit();
  }
}
