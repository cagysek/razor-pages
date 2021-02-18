using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;

namespace AccountingApp.Pages.Accountant.Invoices
{
    /// <summary>
    /// PageModel for invoice detal
    /// accessible for all
    /// </summary>
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Binded property for view. Represents invoice
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// GET action, shows invoice detail
        /// </summary>
        /// <param name="id">ID of invoice to show</param>
        /// <returns>Page vith invoice detail</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // retrieves invoice from db
            Invoice = await _context.Invoice
                                        .Include(i => i.BillToCompany).ThenInclude(b => b.Address)
                                        .Include(i => i.Suppliercompany).ThenInclude(b => b.Address)
                                        .Include(i => i.InvoiceItems)
                                        .FirstOrDefaultAsync(m => m.ID == id);

            if (Invoice == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
