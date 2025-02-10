using Microsoft.AspNetCore.Mvc;
using API_Oficina.Domain;
using API_Oficina.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeService _workTypeService;

        public WorkTypeController(IWorkTypeService workTypeService)
        {
            _workTypeService = workTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkType>>> GetWorkTypes()
        {
            var workTypes = await _workTypeService.GetAllWorkTypesAsync();
            return workTypes == null || !workTypes.Any() ? NotFound() : Ok(workTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkType>> GetWorkType(int id)
        {
            var workType = await _workTypeService.GetWorkTypeByIdAsync(id);
            return workType == null ? NotFound() : Ok(workType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkType(int id, WorkType workType)
        {
            if (id != workType.Id) return BadRequest();
            var updated = await _workTypeService.UpdateWorkTypeAsync(workType);
            return updated ? NoContent() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<WorkType>> CreateWorkType(WorkType workType)
        {
            var createdWorkType = await _workTypeService.CreateWorkTypeAsync(workType);
            return createdWorkType == null ? BadRequest() : CreatedAtAction(nameof(GetWorkType), new { id = createdWorkType.Id }, createdWorkType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkType(int id)
        {
            var deleted = await _workTypeService.DeleteWorkTypeAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}