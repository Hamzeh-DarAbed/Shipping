using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Context;
using Shipping.Entities;
using Shipping.repo.IRepositories;

namespace Shipping.repo.Repositories
{
    public class PackageRepo:Repository<Package, string>,IPackageRepository
    {
        public PackageRepo(ApplicationDbContext context) : base(context)
        {
            
        }
    }
    
}