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
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    // [HttpPost]
    // public async Task<IActionResult> Create(Product product)
    // {

    //     var created = await _service.AddAsync(product);
    //     return CreatedAtAction(nameof(GetById), new { id = created.id }, created);
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update(int id, Product updatedProduct)
    // {
    //     if (id != updatedProduct.id) return BadRequest("ID mismatch");
    //     var updated = await _service.UpdateAsync(updatedProduct);
    //     return updated is null ? NotFound() : Ok(updated);
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     var success = await _service.DeleteAsync(id);
    //     return success ? NoContent() : NotFound();
    // }
}
