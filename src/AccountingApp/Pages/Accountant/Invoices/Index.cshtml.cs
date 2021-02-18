using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;

namespace AccountingApp.Pages.Accountant.Invoices
{
    /// <summary>
    /// Page model for list of invoices
    /// Accessible for all
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Binded property. Contains list of invoices
        /// </summary>
        public IList<Invoice> InvoiceList { get; set; }

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET action. Shows list of invoices
        /// </summary>
        /// <returns>Page with invoices in system</returns>
        public async Task OnGetAsync()
        {
            InvoiceList = await _context.Invoice
                                        .Include(i => i.BillToCompany)
                                        .Include(i => i.Suppliercompany)
                                        .ToListAsync();
        }
    }
}
