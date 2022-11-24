using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shipping.Entities;
using Shipping.repo;

namespace Shipping.Test.FakeRepo
{
    public class ShippingServiceRepoFake:IRepository<ShippingService,string>
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

        

        public ShippingService Get(string id)
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