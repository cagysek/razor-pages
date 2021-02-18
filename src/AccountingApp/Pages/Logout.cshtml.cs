using AccountingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingApp.Pages
{
    /// <summary>
    /// PageModel for log out user
    /// </summary>
    public class LogoutModel : PageModel
    {
        /// <summary>
        /// Session service
        /// </summary>
        private readonly ISessionService _sessionService;

        public LogoutModel(ISessionService _sessionService)
        {
            this._sessionService = _sessionService;
        }

        /// <summary>
        /// Delete user session
        /// </summary>
        /// <returns>Index page</returns>
        public IActionResult OnPost()
        {
            this._sessionService.LogoutUser();

            return RedirectToPage("/Index");
        }
    }
}
