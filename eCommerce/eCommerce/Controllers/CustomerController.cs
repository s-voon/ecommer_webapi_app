using eCommerce.DbContexts;
using eCommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController: ControllerBase
    {
        private readonly TransactionContext _context;

        public CustomerController(TransactionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(int customerId, Customer customer)
        {
            Customer customerRetrieved = await _context.Customers.FindAsync(customerId);

            if(customerRetrieved == null)
            { return NotFound(); }

            customerRetrieved.CustomerName = customer.CustomerName;
            customerRetrieved.CustomerEmail = customer.CustomerEmail;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(int customerId)
        {
            Customer customer = await _context.Customers.FindAsync(customerId);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
