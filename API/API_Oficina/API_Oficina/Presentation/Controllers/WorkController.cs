using Microsoft.AspNetCore.Mvc;
using API_Oficina.Domain;
using API_Oficina.Application;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWorks()
        {
            var works = await _workService.GetAllWorksAsync();
            return works == null || !works.Any() ? NotFound() : Ok(works);
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(int id)
        {
            var work = await _workService.GetWorkByIdAsync(id);
            return work == null ? NotFound() : Ok(work);
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWork(int id, Work work)
        {
            if (id != work.Id)
                return BadRequest();

            var updated = await _workService.UpdateWorkAsync(work);
            return updated ? NoContent() : NotFound();
        }

        // POST: api/Works
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Work>> CreateWork(Work work)
        {
            var createdWork = await _workService.CreateWorkAsync(work);
            return createdWork == null ? BadRequest() : CreatedAtAction(nameof(GetWork), new { id = createdWork.Id }, createdWork);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var deleted = await _workService.DeleteWorkAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("Average/{workTypeId?}")]
        public async Task<IActionResult> GetAveragePriceByWorkType(int? workTypeId)
        {
            var media = await _workService.EstimatePriceByByWorkTypeAsync(workTypeId);
            return Ok(media);
        }
    }
}
