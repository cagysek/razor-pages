using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Users
{
    /// <summary>
    /// Page model for user detail
    /// Accessible for role admin
    /// </summary>
    public class DetailsModel : AuthenticatedPageModel
    {
        /// <summary>
        /// List of roles with access
        /// </summary>
        protected override List<String> RoleAccess { get; set; } = new List<string>()
        {
            ERole.Admin
        };

        /// <summary>
        /// Database context
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Binded property for view. Represents user object
        /// </summary>
        public AppUser AppUser { get; set; }

        public DetailsModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action. Shows information about user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Shows page with user detail</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
