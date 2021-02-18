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
    /// PageModel for list of users
    /// Accessible for admin
    /// </summary>
    public class IndexModel : AuthenticatedPageModel
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
        /// Binded property for view. Contains list of users
        /// </summary>
        public IList<AppUser> AppUser { get; set; }

        public IndexModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action. Shows page with users
        /// </summary>
        /// <returns>Page with users</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            AppUser = await _context.AppUser
                .Include(a => a.Role)
                .AsNoTracking()
                .ToListAsync();

            return Page();
        }
    }
}
