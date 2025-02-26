using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.OrderRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.OrderRepository
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, SimpleContextDb>, IOrderDal
    {
        public async Task<List<OrderDto>> GetListDto()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from order in context.Orders
                             join customer in context.Customers on order.CustomerId equals customer.Id
                             select new OrderDto
                             {
                                 Id = order.Id,
                                 CustomerId = order.CustomerId,
                                 CustomerName = customer.Name,
                                 OrderDate = order.OrderDate,
                                 OrderNumber = order.OrderNumber,
                                 Status = order.Status,
                                 Quantity = context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Quantity),
                                 Total = context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Price) * context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Quantity)
                             };
                return await result.OrderByDescending(p => p.Id).ToListAsync();
            }
        }

        public async Task<List<OrderDto>> GetListByCustomerIdDto(int customerId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from order in context.Orders.Where(p => p.CustomerId == customerId)
                             join customer in context.Customers on order.CustomerId equals customer.Id
                             select new OrderDto
                             {
                                 Id = order.Id,
                                 CustomerId = order.CustomerId,
                                 CustomerName = customer.Name,
                                 OrderDate = order.OrderDate,
                                 OrderNumber = order.OrderNumber,
                                 Status = order.Status,
                                 Quantity = context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Quantity),
                                 Total = context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Price) * context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Quantity)
                             };
                return await result.OrderByDescending(p => p.Id).ToListAsync();
            }
        }

        public async Task<OrderDto> GetByIdDto(int id)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from order in context.Orders.Where(p => p.Id == id)
                             join customer in context.Customers on order.CustomerId equals customer.Id
                             select new OrderDto
                             {
                                 Id = order.Id,
                                 CustomerId = order.CustomerId,
                                 CustomerName = customer.Name,
                                 OrderDate = order.OrderDate,
                                 OrderNumber = order.OrderNumber,
                                 Status = order.Status,
                                 Quantity = context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Quantity),
                                 Total = context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Price) * context.OrderDetails.Where(p => p.OrderId == order.Id).Sum(s => s.Quantity)
                             };
                return await result.FirstOrDefaultAsync();
            }
        }
        public string GetOrderNumber()
        {
            using (var context = new SimpleContextDb())
            {
                var findLastOrder = context.Orders.OrderByDescending(p => p.Id).LastOrDefault();
                if (findLastOrder==null)
                {
                    return "SP00000000000001";
                }
                string findLastOrderNumber = findLastOrder.OrderNumber;
                findLastOrderNumber = findLastOrderNumber.Substring(2, 14);
                int orderNumberint = Convert.ToInt16(findLastOrderNumber);
                orderNumberint++;
                string newOrderNumber = orderNumberint.ToString();
                for (int i = newOrderNumber.Length; i <15 ; i++)
                {
                    newOrderNumber = "0" + newOrderNumber;
                }

                newOrderNumber = "SP" + newOrderNumber;
                return newOrderNumber;
            }
        }
    }
}
