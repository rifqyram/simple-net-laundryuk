using Microsoft.AspNetCore.Mvc;
using SimpleLaundryuk.Application.Models.Bill;
using SimpleLaundryuk.Application.Services.BillServices;

namespace SImpleLaundryuk.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly IBillService _billService;

    public TransactionController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewTransaction([FromBody] RegisterNewBillRequest request)
    {
        var billResponse = await _billService.CreateTransaction(request);
        return Created("/api/transactions", billResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionById(string id)
    {
        var billResponse = await _billService.GetTransactionById(id);
        return Ok(billResponse);
    }

    [HttpGet("report")]
    public async Task<IActionResult> GetReport()
    {
        var billResponses = await _billService.GetReport();
        return Ok(billResponses);
    }
}