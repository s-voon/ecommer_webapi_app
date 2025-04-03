using eCommerce.DbContexts;
using eCommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        private readonly TransactionContext _context;

        public ProductController(TransactionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct (int id, Product product)
        {
            Product productRetrieved = await _context.Products.FindAsync(id);
            
            if(productRetrieved == null)
            { return NotFound(); }

            productRetrieved.productDescription = product.productDescription;
            productRetrieved.price = product.price;
            productRetrieved.productName = product.productName;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            Product productRetrieved = await _context.Products.FindAsync(productId);

            if (productRetrieved == null)
            { return NotFound(); }

            _context.Products.Remove(productRetrieved);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
