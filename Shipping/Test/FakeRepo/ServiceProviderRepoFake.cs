using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.repo;
using Shipping.Entities;
using ServiceProvider = Shipping.Entities.ServiceProvider;
using System.Linq.Expressions;

namespace Shipping.Test.FakeRepo
{
    public class ServiceProviderRepoFake : IRepository<ServiceProvider, string>
    {
        private readonly List<ServiceProvider> _serviceProviders;
        public ServiceProviderRepoFake()
        {
            _serviceProviders = new List<ServiceProvider>(){
                new ServiceProvider(){
                    CarrierId="fedex"
                },
                new ServiceProvider(){
                    CarrierId="ups"
                }
            };

        }
        public ServiceProvider Get(string id)
        {
            var serviceProvider = _serviceProviders.FirstOrDefault(x => x.CarrierId == id);
            serviceProvider.ShippingService = new List<ShippingService>()
            {
                new ShippingService()
                {
                    ShippingServiceId = "fedexAIR"
                },
                new ShippingService()
                {
                    ShippingServiceId = "fedexGROUND"
                }
            };
            return serviceProvider;

        }
        public void Add(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ServiceProvider> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceProvider> Find(Expression<Func<ServiceProvider, bool>> predicate)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<ServiceProvider> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ServiceProvider> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceProvider entity)
        {
            throw new NotImplementedException();
        }
    }
}