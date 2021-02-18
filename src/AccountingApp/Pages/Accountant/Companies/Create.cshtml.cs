using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Accountant.Companies
{
    /// <summary>
    /// PageModel for create company
    /// Accessible only to the role accountant
    /// </summary>
    public class CreateModel : AuthenticatedPageModel
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

        public CreateModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET method for PageModel
        /// </summary>
        /// <returns>Empty page with template for create company</returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// POST method for PageModel
        /// proccess form for create company
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check valid model
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            // add company to database
            _context.Company.Add(Company);

            // save changes
            await _context.SaveChangesAsync();

            TempData[EFlashMessage.Success] = "Společnost vytvořena";

            return RedirectToPage("./Index");
        }
    }
}
