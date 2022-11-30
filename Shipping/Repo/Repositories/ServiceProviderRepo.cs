using Shipping.Context;
using Shipping.Entities;
using Shipping.repo.IRepositories;

namespace Shipping.repo.Repositories
{
    public class ServiceProviderRepo:Repository<ServiceProviderEntity, string>,IServiceProviderRepository
    {
        public ServiceProviderRepo(ApplicationDbContext context) : base(context)
        {
            
        }
    }
    
}