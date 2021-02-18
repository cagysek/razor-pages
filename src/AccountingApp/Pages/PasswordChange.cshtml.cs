using System.Threading.Tasks;
using AccountingApp.Enum;
using AccountingApp.Models.ViewModels;
using AccountingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AccountingApp
{
    /// <summary>
    /// PageModel for change logged user password
    /// </summary>
    public class PasswordChangeModel : PageModel
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
        /// Binded property for view. ViewModel for this view
        /// </summary>
        [BindProperty]
        public PasswordChange PasswordChange { get; set; }

        public PasswordChangeModel(DatabaseContext context, ISessionService sessionService)
        {
            this._context = context;
            this._sessionService = sessionService;
        }

        /// <summary>
        /// GET action. Returns form
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// POST action. Process form for change password
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // check if model is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // get user id from session
            var id = this._sessionService.GetUserId();

            if (id == null)
            {
                return RedirectToPage("/Index");
            }

            // load user from database
            var appUser = await _context.AppUser.FirstOrDefaultAsync(m => m.Id == id);

            if (appUser == null)
            {
                return RedirectToPage("/Index");
            }

            // first check if old password is same as user password
            if (BCrypt.Net.BCrypt.Verify(PasswordChange.OldPassword, appUser.Password))
            {
                // check if new passwords equals
                if (PasswordChange.NewPassword.Equals(PasswordChange.ConfirmPassword))
                {
                    // hash new password
                    appUser.Password = BCrypt.Net.BCrypt.HashPassword(PasswordChange.NewPassword);

                    // mark password to update
                    _context.AppUser.Attach(appUser);
                    _context.Entry(appUser).Property(x => x.Password).IsModified = true;

                    // save changes
                    _context.SaveChanges();
                }
                else
                {
                    TempData[EFlashMessage.Error] = "Nové heslo se neshoduje v potvrzovacím";
                    return Page();
                }
            }
            else
            {
                TempData[EFlashMessage.Error] = "Staré heslo se neshoduje.";
                return Page();
            }

            TempData[EFlashMessage.Success] = "Heslo bylo úspěšně změněno";
            return RedirectToPage("/User/Details");
        }
    }
}
