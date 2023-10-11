using Microsoft.AspNetCore.Mvc;
using SaleHub.Api.Models;
using SaleHub.Api.Contracts;

namespace SaleHub.Api.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly SaleHubContext _context;

        public ProductsController(SaleHubContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<List<Product>> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetById(long id)
        {
            Product? product = _context.Products.Find(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]        
        public ActionResult<Product> Create(CreateProductDTO createProductDTO)
        {            
            Product product = new(){
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public ActionResult<Product> Update(long id, CreateProductDTO createProductDTO)
        {
            Product? product = _context.Products.Find(id);

            if (product == null) return NotFound();

            product.Name = createProductDTO.Name;
            product.Description = createProductDTO.Description;
            product.Price = createProductDTO.Price;

            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            Product? product = _context.Products.Find(id);

            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}