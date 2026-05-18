using AtmDashboard.DataLayer.Context;
using AtmDashboard.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtmDashboard.DataLayer.Repositories;

public class AtmRepository : IAtmRepository
{
    private readonly AtmDbContext _context;

    public AtmRepository(AtmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AtmBalanceFile>> GetLatestBalancesAsync()
    {
        var latestFileName = await _context.AtmBalanceFiles
            .AsNoTracking()
            .OrderByDescending(b => b.BalanceDate)
            .Select(b => b.FileName)
            .FirstOrDefaultAsync();

        if (latestFileName == null)
            return Enumerable.Empty<AtmBalanceFile>();

        return await _context.AtmBalanceFiles
            .AsNoTracking()
            .Where(b => b.FileName == latestFileName)
            .ToListAsync();
    }

    public async Task<IEnumerable<AtmStatusFile>> GetLatestStatusesAsync()
    {
        var latestFileName = await _context.AtmStatusFiles
            .AsNoTracking()
            .OrderByDescending(s => s.FileDate)
            .Select(s => s.FileName)
            .FirstOrDefaultAsync();

        if (latestFileName == null)
            return Enumerable.Empty<AtmStatusFile>();

        return await _context.AtmStatusFiles
            .AsNoTracking()
            .Where(s => s.FileName == latestFileName)
            .ToListAsync();
    }
}
