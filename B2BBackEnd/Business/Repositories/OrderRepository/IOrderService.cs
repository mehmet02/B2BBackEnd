using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.OrderRepository
{
    public interface IOrderService
    {
        Task<IResult> Add(int customerid);
        Task<IResult> Update(Order order);
        Task<IResult> Delete(Order order);
        Task<IDataResult<List<Order>>> GetList();
        Task<IDataResult<Order>> GetById(int id);
        Task<IDataResult<List<OrderDto>>> GetListDto();
        Task<IDataResult<List<OrderDto>>> GetListByCustomerIdDto(int customerId);
        Task<IDataResult<List<Order>>> GetListByCustomerId(int customerId);
        Task<IDataResult<OrderDto>> GetByIdDto(int id);
    }
}
