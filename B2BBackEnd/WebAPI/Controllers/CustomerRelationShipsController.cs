using Business.Repositories.CustomerRelationShipRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRelationShipsController : ControllerBase
    {
        private readonly ICustomerRelationShipService _customerRelationShipService;

        public CustomerRelationShipsController(ICustomerRelationShipService customerRelationShipService)
        {
            _customerRelationShipService = customerRelationShipService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CustomerRelationShip customerRelationShip)
        {
            var result = await _customerRelationShipService.Add(customerRelationShip);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CustomerRelationShip customerRelationShip)
        {
            var result = await _customerRelationShipService.Update(customerRelationShip);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CustomerRelationShip customerRelationShip)
        {
            var result = await _customerRelationShipService.Delete(customerRelationShip);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _customerRelationShipService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerRelationShipService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
