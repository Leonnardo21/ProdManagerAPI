using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdManager.Data;
using ProdManager.Entities;
using ProdManager.Extensions;
using ProdManager.Repositories.Interface;
using ProdManager.ViewEntities;

namespace ProdManager.Controllers
{
    [ApiController]
    [Route("v1")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return Ok(new ResultViewEntities<List<Product>>(products.ToList()));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<Product>("PCXE01 - Falha Interna no Servidor"));
            }
        }

        [HttpGet]
        [Route("products/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                    return NotFound(new ResultViewEntities<Product>("PCXE02 - Conteúdo não encotrado"));
                return Ok(new ResultViewEntities<Product>(product));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<Product>("PCXE02 - Falha Interna no Servidor"));
            }
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> PostAsync([FromBody] EditorProductViewEntities model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewEntities<Product>(ModelState.GetErrors()));

            try
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    CodeBar = model.CodeBar,
                    Category = model.Category,
                    Supplier = model.Supplier,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Lot = model.Lot,
                    Manufacture = model.Manufacture,
                    Expiration = model.Expiration
                };

                await _productRepository.PostAsync(product);
                return Created($"v1/products/{product.Id}", new ResultViewEntities<Product>(product));
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<Product>("PCXE03 - Falha Interna no Servidor"));
            }
        }

        [HttpPut]
        [Route("products/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorProductViewEntities model)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product == null)
                    return NotFound(new ResultViewEntities<Product>("PCXE04 - Conteúdo não encontrado"));

                product.Name = model.Name;
                product.Description = model.Description;
                product.CodeBar = model.CodeBar;
                product.Category = model.Category;
                product.Supplier = model.Supplier;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.Lot = model.Lot;
                product.Manufacture = model.Manufacture;
                product.Expiration = model.Expiration;

                await _productRepository.PutAsync(product);
                return Ok(product);
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<Product>("PCXE04 - Falha Interna no Servidor"));
            }
        }

        [HttpDelete]
        [Route("products/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                    return NotFound(new ResultViewEntities<Product>("PCXE05 - Conteúdo não encontrado"));

                await _productRepository.DeleteAsync(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, new ResultViewEntities<Product>("PCXE05 - Falha Interna no Servidor"));
            }
        }
    }
}