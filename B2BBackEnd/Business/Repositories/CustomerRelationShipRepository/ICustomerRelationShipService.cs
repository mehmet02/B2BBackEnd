using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.CustomerRelationShipRepository
{
    public interface ICustomerRelationShipService
    {
        Task<IResult> Add(CustomerRelationShip customerRelationShip);
        Task<IResult> Update(CustomerRelationShip customerRelationShip);
        Task<IResult> Delete(CustomerRelationShip customerRelationShip);
        Task<IDataResult<List<CustomerRelationShip>>> GetList();
        Task<IDataResult<CustomerRelationShip>> GetById(int id);
    }
}
