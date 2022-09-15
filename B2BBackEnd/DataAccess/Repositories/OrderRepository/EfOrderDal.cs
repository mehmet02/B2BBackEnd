using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.OrderRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.OrderRepository
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, SimpleContextDb>, IOrderDal
    {
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
