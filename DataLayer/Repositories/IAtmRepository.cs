using AtmDashboard.DomainModel.Entities;

namespace AtmDashboard.DataLayer.Repositories;

public interface IAtmRepository
{
    Task<IEnumerable<AtmBalanceFile>> GetLatestBalancesAsync();
    Task<IEnumerable<AtmStatusFile>> GetLatestStatusesAsync();
}
