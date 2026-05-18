using AtmDashboard.DataLayer.Repositories;
using AtmDashboard.DomainModel.DTOs;
using AtmDashboard.DomainModel.Entities;

namespace AtmDashboard.BusinessLayer.Services;

public class AtmService : IAtmService
{
    private readonly IAtmRepository _repository;

    public AtmService(IAtmRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AtmBalanceDto>> GetLatestBalancesAsync()
    {
        var entities = await _repository.GetLatestBalancesAsync();
        return entities.Select(MapToDto);
    }

    public async Task<IEnumerable<AtmStatusDto>> GetLatestStatusesAsync()
    {
        var entities = await _repository.GetLatestStatusesAsync();
        return entities.Select(MapToDto);
    }

    private static AtmBalanceDto MapToDto(AtmBalanceFile e) => new()
    {
        RecordId = e.RecordId,
        FileName = e.FileName,
        BalanceDate = e.BalanceDate,
        AtmName = e.AtmName,
        AtmId = e.AtmId,
        TerminalId = e.TerminalId,
        Branch = e.Branch,
        InitialBalanceAll = e.InitialBalanceAll,
        RemainingBalanceAll = e.RemainingBalanceAll,
        NoTransactionsAll = e.NoTransactionsAll,
        NoWithdrawalsAll = e.NoWithdrawalsAll,
        EurInitial = e.EurInitial,
        EurRemaining = e.EurRemaining,
        Timestamp = e.Timestamp
    };

    private static AtmStatusDto MapToDto(AtmStatusFile e) => new()
    {
        RecordId = e.RecordId,
        FileName = e.FileName,
        FileDate = e.FileDate,
        AtmPID = e.AtmPID,
        AtmName = e.AtmName,
        Status = e.Status,
        NET = e.NET,
        CrdReader = e.CrdReader,
        Dispenser = e.Dispenser,
        Encryptor = e.Encryptor,
        Depository = e.Depository,
        BilCas1 = e.BilCas1,
        BilCas2 = e.BilCas2,
        BilCas3 = e.BilCas3,
        BilCas4 = e.BilCas4,
        BilCas5 = e.BilCas5,
        BilCas6 = e.BilCas6,
        BilCas7 = e.BilCas7,
        PrintUser = e.PrintUser,
        Door = e.Door,
        CardBin = e.CardBin,
        RejBin = e.RejBin,
        Owner = e.Owner,
        SupVs = e.SupVs,
        Branch = e.Branch
    };
}
