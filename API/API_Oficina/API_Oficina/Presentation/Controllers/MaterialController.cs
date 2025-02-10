using Microsoft.AspNetCore.Mvc;
using API_Oficina.Domain;
using API_Oficina.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
        {
            var materials = await _materialService.GetAllMaterialsAsync();
            return materials == null || !materials.Any() ? NotFound() : Ok(materials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _materialService.GetMaterialByIdAsync(id);
            return material == null ? NotFound() : Ok(material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, Material material)
        {
            if (id != material.Id) return BadRequest();
            var updated = await _materialService.UpdateMaterialAsync(material);
            return updated ? NoContent() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Material>> CreateMaterial(Material material)
        {
            var createdMaterial = await _materialService.CreateMaterialAsync(material);
            return createdMaterial == null ? BadRequest() : CreatedAtAction(nameof(GetMaterial), new { id = createdMaterial.Id }, createdMaterial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var deleted = await _materialService.DeleteMaterialAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}