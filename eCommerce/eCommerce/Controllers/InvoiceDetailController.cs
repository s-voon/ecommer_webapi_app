using eCommerce.DbContexts;
using eCommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("invoiceDetails")]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly TransactionContext _context;

        public InvoiceDetailController(TransactionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetInvoiveDetails()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoiceDetailById(int id)
        {
            InvoiceDetail invoiceDetail = await _context.InvoiceDetails.Where(x => x.InvoiceDetailId == id).FirstAsync();
            if (invoiceDetail == null) { return NotFound(); }

            return invoiceDetail;
        }

        [HttpPost]
        public async Task<ActionResult> AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{invoiceDetailId}")]
        public async Task<ActionResult> UpdateInvoiceDetailById(int invoiceDetailId, InvoiceDetail invoiceDetail)
        {
            InvoiceDetail invoiceDetailRetrieved = await _context.InvoiceDetails.FindAsync(invoiceDetailId);

            if (invoiceDetailRetrieved == null)
            {
                return NotFound();
            }

            invoiceDetailRetrieved.InvoiceId = invoiceDetail.InvoiceId;
            invoiceDetailRetrieved.ProductId = invoiceDetail.ProductId;
            invoiceDetailRetrieved.Quantity = invoiceDetail.Quantity;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{invoiceDetailId}")]
        public async Task<ActionResult> DeleteInvoiceDetailById(int invoiceDetailId)
        {
            InvoiceDetail invoiceDetailRetrieved = await _context.InvoiceDetails.FindAsync(invoiceDetailId);

            if (invoiceDetailRetrieved == null)
            {
                return NotFound();
            }

            _context.InvoiceDetails.Remove(invoiceDetailRetrieved);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
