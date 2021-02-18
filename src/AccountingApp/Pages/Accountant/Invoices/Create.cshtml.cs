using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Accountant.Invoices
{
    /// <summary>
    /// PageModel for create Invoice
    /// Accessible only to the role accountant
    /// </summary>
    public class CreateModel : AuthenticatedPageModel
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

        /// <summary>
        /// Binded property for view. List of companies for select
        /// </summary>
        [BindProperty]
        public IList<SelectListItem> CompaniesList { get; set; }

        /// <summary>
        /// Binded property for view. Represents Invoice object
        /// </summary>
        [BindProperty]
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Binded property for view. Contains selected value for bill company
        /// </summary>
        [BindProperty]
        public int SelectBillCompany { get; set; }

        /// <summary>
        /// Binded property for view. Contains selected value for supplier company
        /// </summary>
        [BindProperty]
        public int SelectSupplierCompany { get; set; }

        public CreateModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action. Cointains empty form for create 
        /// </summary>
        /// <returns>View for create invoice</returns>
        public IActionResult OnGet()
        {
            LoadCompaniesList();

            return Page();
        }

        /// <summary>
        /// POST action. Proccess form for create new invoice
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check valid model
            if (!ModelState.IsValid)
            {
                LoadCompaniesList();

                return Page();
            }

            // set up supplier and billing company based on selected values
            Invoice.Suppliercompany = await _context.Company.FindAsync(SelectSupplierCompany);
            Invoice.BillToCompany = await _context.Company.FindAsync(SelectBillCompany);

            // add new invoice
            _context.Invoice.Add(Invoice);

            // save changes
            await _context.SaveChangesAsync();

            TempData[EFlashMessage.Success] = "Faktura vytvořena.";

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Loads list of companies for select inputs
        /// </summary>
        public void LoadCompaniesList()
        {
            CompaniesList = _context.Company
                            .Select(a =>
                                new SelectListItem
                                {
                                    Value = a.ID.ToString(),
                                    Text = a.Title
                                }).ToList();
        }
    }
}
