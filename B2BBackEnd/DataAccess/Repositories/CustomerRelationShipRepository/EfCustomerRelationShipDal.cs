using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CustomerRelationShipRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.CustomerRelationShipRepository
{
    public class EfCustomerRelationShipDal : EfEntityRepositoryBase<CustomerRelationShip, SimpleContextDb>, ICustomerRelationShipDal
    {
    }
}
