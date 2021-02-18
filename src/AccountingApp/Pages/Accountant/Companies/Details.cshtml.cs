using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Accountant.Companies
{
    /// <summary>
    /// PageModel for detail of company
    /// Accessible only to the role accountant
    /// </summary>
    public class DetailsModel : AuthenticatedPageModel
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

        public DetailsModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        
        /// <summary>
        /// GET action for page model
        /// Obtain information about company and pass the information to view
        /// </summary>
        /// <param name="id">ID of company to display information</param>
        /// <returns></returns>
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
    }
}
