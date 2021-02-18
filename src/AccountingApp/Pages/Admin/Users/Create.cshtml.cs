using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountingApp.Models;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Users
{
    /// <summary>
    /// PageModel for create user
    /// Accessible only for role Admin
    /// </summary>
    public class CreateModel : AuthenticatedPageModel
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
        /// Binded property view. Contains roles to select input
        /// </summary>
        [BindProperty]
        public IList<SelectListItem> Roles { get; set; }

        /// <summary>
        /// Binded property to view. Contains selected role
        /// </summary>
        [BindProperty]
        public int SelectedRole { get; set; }

        /// <summary>
        /// Binded property to view. Represents user object
        /// </summary>
        [BindProperty]
        public AppUser AppUser { get; set; }

        public CreateModel(DatabaseContext context, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
        }

        /// <summary>
        /// GET action. Shows form for create user
        /// </summary>
        /// <returns>Page with form for create user</returns>
        public IActionResult OnGet()
        {
            // add roles to view from database
            this.LoadRoles();

            return Page();
        }

        /// <summary>
        /// POST action. Process form
        /// </summary>
        /// <returns>Index page if everything is OK, else current page with errors</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check model
            if (!ModelState.IsValid)
            {
                // load roles to view
                this.LoadRoles();

                return Page();
            }

            // check if username is not used
            if (!VerifyUsername(AppUser.UserName, AppUser.Id))
            {
                TempData[EFlashMessage.Error] = "Uživatelské jméno je již použito";

                // load roles to view
                this.LoadRoles();

                return Page();
            }

            // encrypt user password
            AppUser.Password = BCrypt.Net.BCrypt.HashPassword(AppUser.Password);

            // find role by selected value
            var role = await _context.Role.FindAsync(SelectedRole);

            // assign role to user
            AppUser.Role = role;

            // add user
            _context.AppUser.Add(AppUser);

            // save changes
            await _context.SaveChangesAsync();

            TempData[EFlashMessage.Success] = "Uživatel vytvořen";

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Method load roles from database to property Roles
        /// </summary>
        public void LoadRoles()
        {
            Roles = _context.Role
                            .Select(a =>
                                new SelectListItem
                                {
                                    Value = a.ID.ToString(),
                                    Text = a.Name
                                }).ToList();
        }

        /// <summary>
        /// Check if username is not used
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userId"></param>
        /// <returns>TRUE if username is used, else FALSE</returns>
        public Boolean VerifyUsername(string username, int userId)
        {
            // try find user by username
            // added condition to exclude current user
            var user = _context.AppUser.Where(a => a.UserName == username).Where(a => a.Id != userId).FirstOrDefault();

            if (user != null)
            {
                return false;
            }

            return true;
        }
    }
}
