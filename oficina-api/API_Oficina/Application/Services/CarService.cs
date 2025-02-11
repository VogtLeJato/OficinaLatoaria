using API_Oficina.Domain;

namespace API_Oficina.Application
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetByIdAsync(id);
        }

        public async Task<Car?> CreateCarAsync(Car car)
        {
            return await _carRepository.AddAsync(car);
        }

        public async Task<bool> UpdateCarAsync(Car car)
        {
            return await _carRepository.UpdateAsync(car);
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            return await _carRepository.DeleteAsync(id);
        }
    }
}
