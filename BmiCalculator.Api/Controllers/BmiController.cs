using BmiCalculator.Api.Models;
using BmiCalculator.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmiCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BmiController : ControllerBase
    {
        private readonly IBmiCalculatorService _bmiCalculatorService = new BmiCalculatorService();
      

        [HttpPost]
        public IActionResult CalculateBmi([FromBody] BmiRequestModel request)
        {
            try
            {
                var result = _bmiCalculatorService.CalculateBmi(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
