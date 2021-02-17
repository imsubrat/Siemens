using Microsoft.AspNetCore.Mvc;
using Siemens.Service;
using Siemens.Model;

namespace Siemens.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private IDiscountService _discountService;

        public PriceController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody]PriceModel model)
        {
            var calculatedModel = _discountService.Calculate(model);
            return Ok(calculatedModel);
        }
    }
}