using Microsoft.AspNetCore.Mvc;
using SimpleLaundryuk.Application.Models.Customer;
using SimpleLaundryuk.Application.Services.CustomerServices;

namespace SImpleLaundryuk.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewCustomer([FromBody] RegisterNewCustomerRequest request)
    {
        var customerResponse = await _service.Create(request);
        return Created("/api/customers", customerResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(string id)
    {
        var customerResponse = await _service.GetById(id);
        return Ok(customerResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
        var customerResponses = await _service.GetAll();
        return Ok(customerResponses);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
    {
        await _service.Update(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteById(id);
        return NoContent();
    }

}