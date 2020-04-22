using System;

namespace RVTR.Lodging.DataContext.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    public void Commit() => throw new NotImplementedException();
  }
}
