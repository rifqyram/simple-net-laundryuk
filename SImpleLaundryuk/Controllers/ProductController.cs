using Microsoft.AspNetCore.Mvc;
using SimpleLaundryuk.Application.Models.Product;
using SimpleLaundryuk.Application.Services.ProductServices;

namespace SImpleLaundryuk.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{

    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewProduct([FromBody] RegisterNewProductRequest request)
    {
        var productResponse = await _service.Create(request);
        return Created("/api/products", productResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var productResponse = await _service.GetById(id);
        return Ok(productResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var productResponses = await _service.GetAll();
        return Ok(productResponses);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        var productResponse = await _service.Update(request);
        return Ok(productResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _service.DeleteById(id);
        return NoContent();
    }
}