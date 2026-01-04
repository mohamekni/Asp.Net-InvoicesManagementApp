using InvoiceManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; } = null!;

        }
}
