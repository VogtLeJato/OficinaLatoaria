using API_Oficina.Application;

public class ProfitForecastService : IProfitForecastService
{
    private readonly IWorkRepository _workRepository;

    public ProfitForecastService(IWorkRepository workRepository)
    {
        _workRepository = workRepository;
    }

    public async Task<float> CalculateProfitForecastAsync(int monthsToConsider)
    {
        var endDate = DateTime.Now;
        var startDate = endDate.AddMonths(-monthsToConsider);

        var completedWorks = await _workRepository.GetCompletedWorksByPeriodAsync(startDate, endDate);

        var totalProfit = completedWorks.Sum(work => work.CurrentPrice);
        var averageMonthlyProfit = totalProfit / monthsToConsider;

        return averageMonthlyProfit;
    }
}