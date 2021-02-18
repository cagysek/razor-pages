using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Services;

namespace AccountingApp.Pages.User
{
    /// <summary>
    /// PageModel for user detail
    /// Accessible for logged user
    /// </summary>
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Session service
        /// </summary>
        private readonly ISessionService _sessionService;

        /// <summary>
        /// Binded property for view. Represents user object
        /// </summary>
        public AppUser AppUser { get; set; }

        public DetailsModel(DatabaseContext context, ISessionService _sessionService)
        {
            _context = context;
            this._sessionService = _sessionService;
        }

        /// <summary>
        /// GET action. Shows detail info about logged user
        /// </summary>
        /// <returns>Page with info about current user</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            // get user id from session
            var id = this._sessionService.GetUserId();

            if (id == null)
            {
                return RedirectToPage("/Index");
            }

            // load info from database to property
            AppUser = await _context.AppUser
                .Include(a => a.Role)
                .Include(a => a.Address)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (AppUser == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
