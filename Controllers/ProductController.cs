using Microsoft.AspNetCore.Mvc;
using Ms1.Models;
using Ms1.Services;

namespace Ms1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly IProductService _service;
  public ProductsController(IProductService service) => _service = service;

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _service.GetAllAsync());
  }
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var product = await _service.GetByIdAsync(id);
    return product is null ? NotFound() : Ok(product);
  }
}
