using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Accountant.Invoices
{
    /// <summary>
    /// Page model for delete invoice
    /// accessible only for role accountant
    /// </summary>
    public class DeleteModel : AuthenticatedPageModel
    {
        /// <summary>
        /// Accessible for roles
        /// </summary>
        protected override List<String> RoleAccess { get; set; } = new List<string>()
        {
            ERole.Accountant
        };

        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;


        public DeleteModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action, delete invoice
        /// </summary>
        /// <param name="id">ID of invoice to delete</param>
        /// <returns>redirect back to list of invoices</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // get invoice by od
            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.ID == id);

            if (invoice == null)
            {
                return NotFound();
            }

            // loads invoice items
            var items = _context.InvoiceItem.Where(i => i.Invoice.ID == id);

            // remove them from invoice
            _context.InvoiceItem.RemoveRange(items);

            // remove invoice
            _context.Invoice.Remove(invoice);

            // save changes
            await _context.SaveChangesAsync();

            TempData[EFlashMessage.Success] = "Odstraněno";

            return RedirectToPage("./Index");
        }
    }
}
