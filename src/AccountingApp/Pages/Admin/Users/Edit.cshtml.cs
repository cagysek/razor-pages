using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;
using AutoMapper;
using AccountingApp.Models.ViewModels;
using AccountingApp.Enum;
using AccountingApp.Services;

namespace AccountingApp.Pages.Users
{
    /// <summary>
    /// Page model for user edit
    /// Accessible for role admin
    /// </summary>
    public class EditModel : AuthenticatedPageModel
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
        /// Mapper object
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Binded property for view. Represents user
        /// </summary>
        [BindProperty]
        public AdminUserEdit AdminUserEdit { get; set; }

        /// <summary>
        /// Binded property for view. Contains avaiable roles
        /// </summary>
        [BindProperty]
        public IList<SelectListItem> Roles { get; set; }

        /// <summary>
        /// Binded property for view. Contains selected role
        /// </summary>
        [BindProperty]
        public int SelectedRole { get; set; }

        public EditModel(DatabaseContext context, IMapper mapper, ISessionService sessionService) : base(sessionService)
        {
            _context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// GET action. Shows page for edit user
        /// </summary>
        /// <param name="id">User id to edit</param>
        /// <returns>Shows page for edit user</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUser
                                .Include(m => m.Address)
                                .Include(m => m.Role)
                                .FirstOrDefaultAsync(m => m.Id == id)
                                ;

            // load available roles
            this.LoadRoles(appUser.Role.ID);

            if (appUser == null)
            {
                return NotFound();
            }

            // map user object to viewModel for user edit
            AdminUserEdit = this.mapper.Map<AdminUserEdit>(appUser);

            return Page();
        }

        /// <summary>
        /// POST action. Process user edit form
        /// </summary>
        /// <returns>If process is without error returns list of index, else current page with error</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check if model is valid
            if (!ModelState.IsValid)
            {
                // load roles to select
                this.LoadRoles(SelectedRole);

                return Page();
            }

            var appUser = new AppUser();

            // map viewmodel back to AppUser
            appUser = this.mapper.Map<AppUser>(AdminUserEdit);


            // check if username is not used
            if (!VerifyUsername(appUser.UserName, appUser.Id))
            {
                TempData[EFlashMessage.Error] = "Uživatelské jméno je již použito";

                // load roles to view
                this.LoadRoles(SelectedRole);

                return Page();
            }

            // find role by selected value
            var role = await _context.Role.FindAsync(SelectedRole);

            // set role to user
            appUser.Role = role;

            // mark values to update
            _context.Attach(appUser).State = EntityState.Modified;
            _context.Attach(appUser.Address).State = EntityState.Modified;

            // if password is not set
            if (AdminUserEdit.NewPassword == null)
            {
                // mark password to not update
                _context.Entry(appUser).Property(x => x.Password).IsModified = false;
            }
            // else encrypt password and set to user
            else
            {
                appUser.Password = BCrypt.Net.BCrypt.HashPassword(AdminUserEdit.NewPassword);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(appUser.Id))
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
        /// Check if user exists
        /// </summary>
        /// <param name="id">user ID</param>
        /// <returns>True if exists, else FALSE</returns>
        private bool AppUserExists(int id)
        {
            return _context.AppUser.Any(e => e.Id == id);
        }

        /// <summary>
        /// Load roles to variable
        /// </summary>
        /// <param name="selectRoleId"></param>
        public void LoadRoles(int selectRoleId)
        {
            Roles = _context.Role
                            .Select(a =>
                                new SelectListItem
                                {
                                    Value = a.ID.ToString(),
                                    Text = a.Name.ToString(),
                                    Selected = a.ID == selectRoleId ? true : false
                                }).ToList();
        }

        /// <summary>
        /// Check if username is not used
        /// </summary>
        /// <param name="username">username to check</param>
        /// <param name="userId">user id for exclude</param>
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
