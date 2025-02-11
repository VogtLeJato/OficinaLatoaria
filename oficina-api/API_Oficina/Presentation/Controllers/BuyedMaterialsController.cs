using Microsoft.AspNetCore.Mvc;
using API_Oficina.Domain;
using API_Oficina.Application;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyedMaterialController : ControllerBase
    {
        private readonly IBuyedMaterialService _buyedMaterialService;

        public BuyedMaterialController(IBuyedMaterialService buyedMaterialService)
        {
            _buyedMaterialService = buyedMaterialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyedMaterial>>> GetBuyedMaterials()
        {
            var buyedMaterials = await _buyedMaterialService.GetAllBuyedMaterialsAsync();
            return buyedMaterials == null || !buyedMaterials.Any() ? NotFound() : Ok(buyedMaterials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuyedMaterial>> GetBuyedMaterial(int id)
        {
            var buyedMaterial = await _buyedMaterialService.GetAllBuyedMaterialsAsync();
            return buyedMaterial == null ? NotFound() : Ok(buyedMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, BuyedMaterial buyedMaterial)
        {
            if (id != buyedMaterial.Id) return BadRequest();
            var updated = await _buyedMaterialService.UpdateBuyedMaterialAsync(buyedMaterial);
            return updated ? NoContent() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(BuyedMaterial buyedMaterial)
        {
            var createdBuyedMaterial = await _buyedMaterialService.CreateBuyedMaterialAsync(buyedMaterial);
            return createdBuyedMaterial == null ? BadRequest() : CreatedAtAction(nameof(GetBuyedMaterial), new { id = buyedMaterial.Id }, buyedMaterial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _buyedMaterialService.DeleteBuyedMaterialAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
