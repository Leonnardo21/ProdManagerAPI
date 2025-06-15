using Microsoft.AspNetCore.Mvc;
using ProdManager.Application;
using ProdManager.Domain.Entities;

namespace ProdManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository  categoryRepository) =>  _categoryRepository = categoryRepository;


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        if (category == null)return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Category category)
    {
        await _categoryRepository.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Category category)
    {
        var categoryToUpdate = await _categoryRepository.GetById(id);
        if (categoryToUpdate == null) return NotFound();
        
        categoryToUpdate.Name = category.Name;
        await _categoryRepository.Update(categoryToUpdate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Detele(int id)
    {
        var categoryId = await _categoryRepository.Delete(id);
        if (!categoryId) return NotFound("Categoria não encontrada");
        return NoContent();
    }
}