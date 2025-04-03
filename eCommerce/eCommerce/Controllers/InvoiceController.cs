using eCommerce.DbContexts;
using eCommerce.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly TransactionContext _context;

        public InvoiceController(TransactionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
        {
            return await _context.Invoices.ToListAsync();
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }

        [HttpPost]
        public async Task<ActionResult> AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{invoiceId}")]
        public async Task<ActionResult> UpdateInvoiceById(int invoiceId, Invoice invoice)
        {
            Invoice invoiceRetrieved = await _context.Invoices.FindAsync(invoiceId);

            if(invoiceRetrieved == null)
            {
                return NotFound();
            }

            invoiceRetrieved.InvoiceDetails = invoice.InvoiceDetails;
            invoiceRetrieved.InvoiceStatus = invoice.InvoiceStatus;
            invoiceRetrieved.CustomerId = invoice.CustomerId;
            invoiceRetrieved.TotalAmount = invoice.TotalAmount;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{invoiceId}")]
        public async Task<ActionResult> DeleteInvoiceById(int invoiceId)
        {
            Invoice invoiceRetrieved = await _context.Invoices.FindAsync(invoiceId);

            if (invoiceRetrieved == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoiceRetrieved);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
