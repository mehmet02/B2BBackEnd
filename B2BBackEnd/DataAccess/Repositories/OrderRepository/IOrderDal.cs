using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.OrderRepository
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        string GetOrderNumber();
        Task<List<OrderDto>> GetListDto();
        Task<List<OrderDto>> GetListByCustomerIdDto(int customerId);
        Task<OrderDto> GetByIdDto(int id);
    }
}
