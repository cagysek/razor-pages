using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Accountant.Invoices
{
    /// <summary>
    /// PageModel for edit invoice
    /// Accessible for role aacountant
    /// </summary>
    public class EditModel : AuthenticatedPageModel
    {
        /// <summary>
        /// List of roles with access
        /// </summary>
        protected override List<String> RoleAccess { get; set; } = new List<string>()
        {
            ERole.Accountant
        };

        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Binded property for view. Represents selected bill company
        /// </summary>
        [BindProperty]
        public int SelectBillCompany { get; set; }

        /// <summary>
        /// Binded property for view. Represents selected supplier company
        /// </summary>
        [BindProperty]
        public int SelectSupplierCompany { get; set; }

        /// <summary>
        /// Binded property for view. Represents invoice
        /// </summary>
        [BindProperty]
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Binded property for view. Contains list of companies for select input
        /// </summary>
        [BindProperty]
        public IList<SelectListItem> CompaniesList { get; set; }

        public EditModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action. Shows edit form for edit invoice
        /// </summary>
        /// <param name="id">ID of invoice to edit</param>
        /// <returns>Page with edit form for inoice</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // loads invoice from database
            Invoice = await _context.Invoice
                                        .Include(i => i.InvoiceItems)
                                        .Include(i => i.BillToCompany)
                                        .Include(i => i.Suppliercompany)
                                        .FirstOrDefaultAsync(m => m.ID == id);

            // check if invoice can be edited (IsStorno == false)
            if (!IsAllowInvoiceEdit(Invoice))
            {
                TempData[EFlashMessage.Error] = "Faktura č. " + Invoice.ID + " je STORNOVÁNA a proto nelze editovat.";

                return RedirectToPage("./Index");
            }

            if (Invoice == null)
            {
                return NotFound();
            }

            // load companies list to select inputs
            LoadCompanyList();

            return Page();
        }

        /// <summary>
        /// POST action. Proccess edit form
        /// </summary>
        /// <returns>If process is without error return index page, else return current page with errors</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check model
            if (!ModelState.IsValid)
            {
                // loads invoice from database
                Invoice = await _context.Invoice
                                            .Include(i => i.InvoiceItems)
                                            .Include(i => i.BillToCompany)
                                            .Include(i => i.Suppliercompany)
                                            .FirstOrDefaultAsync(m => m.ID == Invoice.ID);

                LoadCompanyList();

                return Page();
            }

            // load selected companies from selects and assign them to invoice
            Invoice.Suppliercompany = await _context.Company.FindAsync(SelectSupplierCompany);
            Invoice.BillToCompany = await _context.Company.FindAsync(SelectBillCompany);

            // mark changes
            _context.Attach(Invoice).State = EntityState.Modified;

            try
            {
                // loads old items
                var items = _context.InvoiceItem.Where(i => i.Invoice.ID == Invoice.ID);

                // remove them from invoice
                _context.InvoiceItem.RemoveRange(items);

                // save changes (EF adds items for us)
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(Invoice.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Loads companies to list
        /// </summary>
        private void LoadCompanyList()
        {
            CompaniesList = _context.Company
                            .Select(a =>
                                new SelectListItem
                                {
                                    Value = a.ID.ToString(),
                                    Text = a.Title
                                }).ToList();
        }

        /// <summary>
        /// Checks if invoice exists
        /// </summary>
        /// <param name="id">ID of invoice to check</param>
        /// <returns>TRUE if exists, else FALSE</returns>
        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.ID == id);
        }

        /// <summary>
        /// Checks if invoice can be edited
        /// </summary>
        /// <param name="invoice">Invoice to check</param>
        /// <returns>True if can be edited, else FALSE</returns>
        private bool IsAllowInvoiceEdit(Invoice invoice)
        {
            return !invoice.IsStorno;
        }
    }
}
