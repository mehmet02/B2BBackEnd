using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.OrderDetailRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.OrderDetailRepository.Validation;
using Business.Repositories.OrderDetailRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.OrderDetailRepository;
using Entities.Dtos;

namespace Business.Repositories.OrderDetailRepository
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [RemoveCacheAspect("IOrderDetailService.Get")]

        public async Task<IResult> Add(OrderDetail orderDetail)
        {
            await _orderDetailDal.Add(orderDetail);
            return new SuccessResult(OrderDetailMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(OrderDetailValidator))]
        [RemoveCacheAspect("IOrderDetailService.Get")]

        public async Task<IResult> Update(OrderDetail orderDetail)
        {
            await _orderDetailDal.Update(orderDetail);
            return new SuccessResult(OrderDetailMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IOrderDetailService.Get")]

        public async Task<IResult> Delete(OrderDetail orderDetail)
        {
            await _orderDetailDal.Delete(orderDetail);
            return new SuccessResult(OrderDetailMessages.Deleted);
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<OrderDetail>>> GetList(int orderid)
        {
            return new SuccessDataResult<List<OrderDetail>>(await _orderDetailDal.GetAll(p=>p.OrderId==orderid));
        }
        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<OrderDetailDto>>> GetListDto(int orderId)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(await _orderDetailDal.GetListDto(orderId));
        }
        public async Task<List<OrderDetail>> GetListByProductid(int productid)
        {
            return await _orderDetailDal.GetAll(p => p.ProductId == productid);
        }

        [SecuredAspect()]
        public async Task<IDataResult<OrderDetail>> GetById(int id)
        {
            return new SuccessDataResult<OrderDetail>(await _orderDetailDal.Get(p => p.Id == id));
        }

    }
}
