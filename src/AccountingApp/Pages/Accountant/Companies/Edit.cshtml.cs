using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Accountant.Companies
{
    /// <summary>
    /// PageModel for edit company
    /// Accessible only to the role accountant
    /// </summary>
    public class EditModel : AuthenticatedPageModel
    {
        /// <summary>
        /// List of roles with access to page
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
        /// Binded property for view. Represents company
        /// </summary>
        [BindProperty]
        public Company Company { get; set; }

        public EditModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action, loads data from database for company ID and pass data to view
        /// </summary>
        /// <param name="id">ID of company to edit</param>
        /// <returns>View for edit company</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company
                                .Include(c => c.Address)
                                .FirstOrDefaultAsync(m => m.ID == id);

            if (Company == null)
            {
                return NotFound();
            }

            return Page();
        }

        /// <summary>
        /// POST action, process data from form and saves changes
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check valid state
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // mark objects to update
            _context.Attach(Company).State = EntityState.Modified;
            _context.Attach(Company.Address).State = EntityState.Modified;

            try
            {
                // save changes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData[EFlashMessage.Success] = "Uloženo";

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Check if company exists
        /// </summary>
        /// <param name="id">ID of company</param>
        /// <returns>TRUE if exists, else FALSE</returns>
        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.ID == id);
        }
    }
}
