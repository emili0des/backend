using AtmDashboard.DomainModel.DTOs;

namespace AtmDashboard.BusinessLayer.Services;

public interface IAtmService
{
    Task<IEnumerable<AtmBalanceDto>> GetLatestBalancesAsync();
    Task<IEnumerable<AtmStatusDto>> GetLatestStatusesAsync();
}
