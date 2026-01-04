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
        public IActionResult Edit(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToAction("Index");
            }
            var InvoiceDto = new InvoiceDto
            {
                
                Number = invoice.Number,
                Status = invoice.Status,
                IssueDate = invoice.IssueDate,
                DueDate = invoice.DueDate,
                Service = invoice.Service,
                UnitPrice = invoice.UnitPrice,
                Quantity = invoice.Quantity,
                ClientName = invoice.ClientName,
                ClientEmail = invoice.ClientEmail,
                ClientPhone = invoice.ClientPhone,
                ClientAddress = invoice.ClientAddress,
            };
            ViewBag.InvoiceId = invoice.Id;
            return View(InvoiceDto);
        }
        [HttpPost]
        public IActionResult Edit(int id, InvoiceDto invoiceDto)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid) {
                return View();
            }
            invoice.Number = invoiceDto.Number;
            invoice.Status = invoiceDto.Status;
            invoice.IssueDate = invoiceDto.IssueDate;
            invoice.DueDate = invoiceDto.DueDate;
                
            invoice.Service = invoiceDto.Service;
            invoice.UnitPrice = invoiceDto.UnitPrice;
            invoice.Quantity = invoiceDto.Quantity;
            invoice.ClientName = invoiceDto.ClientName;
            invoice.ClientEmail = invoiceDto.ClientEmail;
            invoice.ClientPhone = invoiceDto.ClientPhone;
            invoice.ClientAddress = invoiceDto.ClientAddress ?? "";
            context.SaveChanges();


            return View();
        }
        public IActionResult Delete(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice != null)
            {
                context.Invoices.Remove(invoice);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
