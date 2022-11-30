using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.repo.IRepositories;

namespace Shipping.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IPackageRepository PackageRepository { get; }
        IServiceProviderRepository ServiceRepository { get; }
        IUserRepository UserRepository { get; }
        int Complete();
    }
   
}