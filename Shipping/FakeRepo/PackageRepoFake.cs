using System.Linq.Expressions;
using Shipping.Entities;
using Shipping.repo;

namespace Shipping.FakeRepo
{
    public class PackageRepoFake : IRepository<Package>
    {
        private readonly List<Package> _packages;
        public PackageRepoFake()
        {
            _packages = new List<Package>();
        }
        public void Add(Package entity)
        {
            _packages.Add(entity);
        }
        public IEnumerable<Package> Find(Expression<Func<Package, bool>> predicate)
        {
            return _packages.Where(predicate.Compile());
        }
        
        public void AddRange(IEnumerable<Package> entities)
        {
            throw new NotImplementedException();
        }



        public Package Get(dynamic id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Package> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Package entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Package> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Package entity)
        {
            throw new NotImplementedException();
        }
    }
}