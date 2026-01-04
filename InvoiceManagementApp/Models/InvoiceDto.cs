using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementApp.Models
{
    public class InvoiceDto
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }

        // service details
        [Required]
        public string Service { get; set; } = "";
        [Required, Display(Name="Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

        // client details
        [Required, Display(Name="Client Name")]
        public string ClientName { get; set; } = "";
        [Required , EmailAddress]
        public string ClientEmail { get; set; } = "";
        [Required , Phone]
        public string ClientPhone { get; set; } = "";

        public string? ClientAddress { get; set; }
    }
}
