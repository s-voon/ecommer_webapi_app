using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DbContexts
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "John Doe", CustomerEmail = "john@example.com" },
                new Customer { CustomerId = 2, CustomerName = "Jane Smith", CustomerEmail = "jane@example.com" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { productId = 1, productName = "Cup", price = 12.00, productDescription = "Pink cup" },
                new Product { productId = 2, productName = "Tumbler", price = 25.99, productDescription = "Snoppy Tumbler" }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceId = 1, CustomerId = 1, InvoiceStatus = "Paid", TotalAmount = 100.50 },
                new Invoice { InvoiceId = 2, CustomerId = 2, InvoiceStatus = "Pending", TotalAmount = 200.75 }
            );

            modelBuilder.Entity<InvoiceDetail>().HasData(
                new InvoiceDetail { InvoiceDetailId = 1, InvoiceId = 1, ProductId = 1, Quantity = 1 },
                new InvoiceDetail { InvoiceDetailId = 2, InvoiceId = 1, ProductId = 2, Quantity = 2 },
                new InvoiceDetail { InvoiceDetailId = 3, InvoiceId = 2, ProductId = 3, Quantity = 1 },
                new InvoiceDetail { InvoiceDetailId = 4, InvoiceId = 2, ProductId = 4, Quantity = 3 }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
