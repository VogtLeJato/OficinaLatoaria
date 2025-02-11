public interface IProfitForecastService
{
    Task<float> CalculateProfitForecastAsync(int monthsToConsider);
}