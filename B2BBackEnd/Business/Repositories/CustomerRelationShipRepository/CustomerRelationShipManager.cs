using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.CustomerRelationShipRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.CustomerRelationShipRepository.Validation;
using Business.Repositories.CustomerRelationShipRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CustomerRelationShipRepository;

namespace Business.Repositories.CustomerRelationShipRepository
{
    public class CustomerRelationShipManager : ICustomerRelationShipService
    {
        private readonly ICustomerRelationShipDal _customerRelationShipDal;

        public CustomerRelationShipManager(ICustomerRelationShipDal customerRelationShipDal)
        {
            _customerRelationShipDal = customerRelationShipDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CustomerRelationShipValidator))]
        [RemoveCacheAspect("ICustomerRelationShipService.Get")]

        public async Task<IResult> Add(CustomerRelationShip customerRelationShip)
        {
            await _customerRelationShipDal.Add(customerRelationShip);
            return new SuccessResult(CustomerRelationShipMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CustomerRelationShipValidator))]
        [RemoveCacheAspect("ICustomerRelationShipService.Get")]

        public async Task<IResult> Update(CustomerRelationShip customerRelationShip)
        {
            await _customerRelationShipDal.Update(customerRelationShip);
            return new SuccessResult(CustomerRelationShipMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ICustomerRelationShipService.Get")]

        public async Task<IResult> Delete(CustomerRelationShip customerRelationShip)
        {
            await _customerRelationShipDal.Delete(customerRelationShip);
            return new SuccessResult(CustomerRelationShipMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CustomerRelationShip>>> GetList()
        {
            return new SuccessDataResult<List<CustomerRelationShip>>(await _customerRelationShipDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<CustomerRelationShip>> GetById(int id)
        {
            return new SuccessDataResult<CustomerRelationShip>(await _customerRelationShipDal.Get(p => p.Id == id));
        }

    }
}
