using AtmDashboard.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AtmDashboard.ApiLayer.Controllers;

[ApiController]
[Route("api/atm")]
public class AtmController : ControllerBase
{
    private readonly IAtmService _service;

    public AtmController(IAtmService service)
    {
        _service = service;
    }

    [HttpGet("balances")]
    public async Task<IActionResult> GetBalances()
    {
        var result = await _service.GetLatestBalancesAsync();
        return Ok(result);
    }

    [HttpGet("statuses")]
    public async Task<IActionResult> GetStatuses()
    {
        var result = await _service.GetLatestStatusesAsync();
        return Ok(result);
    }
}
