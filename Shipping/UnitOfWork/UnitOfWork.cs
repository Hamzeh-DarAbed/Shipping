using Shipping.Context;
using Shipping.repo.IRepositories;
using Shipping.repo.Repositories;

namespace Shipping.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        public IPackageRepository PackageRepository { get;}
        public IServiceProviderRepository ServiceRepository { get; }

        public IUserRepository UserRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            PackageRepository = new PackageRepo(_context);
            ServiceRepository = new ServiceProviderRepo(_context);
            UserRepository = new UserRepository(_context, _config);
        }
     
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}