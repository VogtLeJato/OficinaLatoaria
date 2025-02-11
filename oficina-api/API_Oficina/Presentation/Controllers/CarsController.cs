using Microsoft.AspNetCore.Mvc;
using API_Oficina.Domain;
using API_Oficina.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Oficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return cars == null || !cars.Any() ? NotFound() : Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            return car == null ? NotFound() : Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            if (id != car.Id) return BadRequest();
            var updated = await _carService.UpdateCarAsync(car);
            return updated ? NoContent() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            var createdCar = await _carService.CreateCarAsync(car);
            return createdCar == null ? BadRequest() : CreatedAtAction(nameof(GetCar), new { id = createdCar.Id }, createdCar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _carService.DeleteCarAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
