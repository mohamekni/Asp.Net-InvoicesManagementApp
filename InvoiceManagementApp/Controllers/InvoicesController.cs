using InvoiceManagementApp.Models;
using InvoiceManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext context;
        public InvoicesController(ApplicationDbContext context)
        {
             this.context = context;
        }
        public IActionResult Index()
        {
            var invoices = context.Invoices.OrderByDescending(inv => inv.Id).ToList();
            return View(invoices);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(InvoiceDto InvoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
                var invoice = new Invoice
                {
                    Number = InvoiceDto.Number,
                    Status = InvoiceDto.Status,
                    IssueDate = InvoiceDto.IssueDate,
                    DueDate = InvoiceDto.DueDate,
                    Service = InvoiceDto.Service,
                    UnitPrice = InvoiceDto.UnitPrice,
                    Quantity = InvoiceDto.Quantity,
                    ClientName = InvoiceDto.ClientName,
                    ClientEmail = InvoiceDto.ClientEmail,
                    ClientPhone = InvoiceDto.ClientPhone,
                    ClientAddress = InvoiceDto.ClientAddress ?? "",
                };
                context.Invoices.Add(invoice);
                context.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}
