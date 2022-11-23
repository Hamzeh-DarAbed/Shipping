using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.repo;
using Shipping.Entities;
using ServiceProvider = Shipping.Entities.ServiceProvider;
using System.Linq.Expressions;

namespace Shipping.FakeRepo
{
    public class ServiceProviderRepoFake : IRepository<ServiceProvider>
    {
        private readonly List<ServiceProvider> _serviceProviders;
        public ServiceProviderRepoFake()
        {
            _serviceProviders= new List<ServiceProvider>(){
                new ServiceProvider(){
                    CarrierId="fedex"
                },
                new ServiceProvider(){
                    CarrierId="ups"
                }
            };

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

        public ServiceProvider Get(dynamic id)
        {
            return _serviceProviders.FirstOrDefault(x => x.CarrierId == id);
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