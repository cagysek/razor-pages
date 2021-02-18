using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AccountingApp.Services;
using AccountingApp.Enum;

namespace AccountingApp.Pages.Accountant.Companies
{
    /// <summary>
    /// PageModel for campanies overview
    /// Accessible only to the role accountant
    /// </summary>
    public class IndexModel : AuthenticatedPageModel
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
        /// Binded property for view. List of companies
        /// </summary>
        public IList<Company> Company { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sessionService"></param>
        public IndexModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        
        /// <summary>
        /// GET action, obtains companies from database and pass them to view
        /// </summary>
        /// <returns>View with list of companies</returns>
        public async Task OnGetAsync()
        {
            Company = await _context.Company.ToListAsync();
        }
    }
}
