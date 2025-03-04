using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.OrderDetailRepository
{
    public interface IOrderDetailService
    {
        Task<IResult> Add(OrderDetail orderDetail);
        Task<IResult> Update(OrderDetail orderDetail);
        Task<IResult> Delete(OrderDetail orderDetail);
        Task<IDataResult<List<OrderDetail>>> GetList(int orderid);
        Task<IDataResult<List<OrderDetailDto>>> GetListDto(int orderId);
        Task<List<OrderDetail>> GetListByProductid(int productid);
        Task<IDataResult<OrderDetail>> GetById(int id);
    }
}
