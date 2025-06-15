using Microsoft.AspNetCore.Mvc;
using ProdManager.Application;
using ProdManager.Domain.Entities;

namespace ProdManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        if(product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        await _productRepository.AddAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Product product)
    {
        var productToUpdate = await _productRepository.GetById(id);
        
        if(productToUpdate == null) return NotFound();
        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        productToUpdate.StockQuantity = product.StockQuantity;
        productToUpdate.Manufacture = product.Manufacture;
        productToUpdate.Expiration = product.Expiration;
        productToUpdate.IsActive = product.IsActive;
        
        _productRepository.Update(productToUpdate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var productToDelete = await _productRepository.Delete(id);

        if (!productToDelete) return NotFound("Produto não encontrado.");
        
        return NoContent();
    }
}