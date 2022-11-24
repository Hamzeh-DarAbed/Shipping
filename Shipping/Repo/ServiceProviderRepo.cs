using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Shipping.Context;
using Shipping.repo;

namespace Shipping.Repo
{
    public class ServiceProviderRepo:IRepository<Entities.ServiceProvider,string>
    {
        private readonly ApplicationDbContext _context;

        public ServiceProviderRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Entities.ServiceProvider entity)
        {
            _context.ServiceProviders.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Entities.ServiceProvider> entities)
        {
            _context.ServiceProviders.AddRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<Entities.ServiceProvider> Find(System.Linq.Expressions.Expression<Func<Entities.ServiceProvider, bool>> predicate)
        {
            return _context.ServiceProviders.Where(predicate);
        }

        public Entities.ServiceProvider Get(string id)
        {
            return _context.ServiceProviders.Include(x=>x.ShippingService).FirstOrDefault(x=>x.CarrierId==id);
        }

        public IEnumerable<Entities.ServiceProvider> GetAll()
        {
            return _context.ServiceProviders.ToList();
        }

        public void Remove(Entities.ServiceProvider entity)
        {
            _context.ServiceProviders.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Entities.ServiceProvider> entities)
        {
            _context.ServiceProviders.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Update(Entities.ServiceProvider entity)
        {
            _context.ServiceProviders.Update(entity);
            _context.SaveChanges();
        }


    }
    
}