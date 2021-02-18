using AccountingApp.Enum;
using AccountingApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AccountingApp.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Session service
        /// </summary>
        private readonly ISessionService _sessionService;

        public IndexModel(ISessionService sessionService)
        {
            this._sessionService = sessionService;
        }

        /// <summary>
        /// Shows index page. Loads error message from session if set
        /// </summary>
        public void OnGet()
        {
            TempData[EFlashMessage.Error] = this._sessionService.GetErrorMessage();
        }
    }
}
