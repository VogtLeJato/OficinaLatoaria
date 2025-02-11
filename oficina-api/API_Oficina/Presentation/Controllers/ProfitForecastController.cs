
using Microsoft.AspNetCore.Mvc;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitForecastController : ControllerBase
    {
        private readonly IProfitForecastService _profitForecastService;
    
        public ProfitForecastController(IProfitForecastService profitForecastService)
        {
            _profitForecastService = profitForecastService;
        }
    
        [HttpGet("ProfitForecast/{monthsToConsider?}")]
        public async Task<IActionResult> GetProfitForecast(int monthsToConsider = 6)
        {
            if (monthsToConsider <= 0) return BadRequest("O número de meses deve ser maior que zero.");
            float forecast = await _profitForecastService.CalculateProfitForecastAsync(monthsToConsider);
            return Ok(forecast);
        }
    }
}