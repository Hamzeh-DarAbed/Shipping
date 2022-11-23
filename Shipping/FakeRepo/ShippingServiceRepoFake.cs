using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shipping.Entities;
using Shipping.repo;

namespace Shipping.FakeRepo
{
    public class ShippingServiceRepoFake:IRepository<ShippingService>
    {
        private readonly List<ShippingService> _shippingServices;
        public ShippingServiceRepoFake()
        {
            _shippingServices=new List<ShippingService>(){
                new ShippingService(){
                    ShippingServiceId="fedexAIR",
                    CarrierId="fedex",
                },
                new ShippingService(){
                    ShippingServiceId="fedexGROUND",
                    CarrierId="fedex",
                },
                new ShippingService(){
                    ShippingServiceId="UPSExpress",
                    CarrierId="ups",
                },
                new ShippingService(){
                    ShippingServiceId="UPS2DAY",
                    CarrierId="ups",
                }
            };
            
        }
        public IEnumerable<ShippingService> Find(Expression<Func<ShippingService, bool>> predicate)
        {
            return _shippingServices.Where(predicate.Compile());
        }

        public void Add(ShippingService entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ShippingService> entities)
        {
            throw new NotImplementedException();
        }

        

        public ShippingService Get(dynamic id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShippingService> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(ShippingService entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ShippingService> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ShippingService entity)
        {
            throw new NotImplementedException();
        }
    }
}