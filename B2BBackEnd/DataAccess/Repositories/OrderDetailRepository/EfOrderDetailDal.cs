using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.OrderDetailRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.OrderDetailRepository
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, SimpleContextDb>, IOrderDetailDal
    {
        public async Task<List<OrderDetailDto>> GetListDto(int orderId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from orderDetail in context.OrderDetails.Where(p => p.OrderId == orderId)
                             join product in context.Products on orderDetail.ProductId equals product.Id
                             select new OrderDetailDto
                             {
                                 Id = orderDetail.Id,
                                 OrderId = orderDetail.OrderId,
                                 Price = orderDetail.Price,
                                 ProductId = orderDetail.ProductId,
                                 ProductName = product.Name,
                                 Quantity = orderDetail.Quantity,
                                 Total = orderDetail.Quantity * orderDetail.Price
                             };
                return await result.ToListAsync();
            }
        }
    }
}
