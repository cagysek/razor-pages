using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingApp.Pages
{
    /// <summary>
    /// Abstract page model for pages with needs role to access
    /// </summary>
    public abstract class AuthenticatedPageModel : PageModel
    {
        /// <summary>
        /// Session service
        /// </summary>
        private ISessionService _sessionService;

        /// <summary>
        /// Abstract list of roles with access to overwrite
        /// </summary>
        protected abstract List<string> RoleAccess { get; set; }

        public AuthenticatedPageModel(ISessionService _sessionService)
        {
            this._sessionService = _sessionService;
        }

        /// <summary>
        /// Override method for OnPageHandlerExecutionAsync.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,PageHandlerExecutionDelegate next)
        {
            // check if user has access
            if (this.HasAccess())
            {
                // show page
                await next.Invoke();
            }

            // redirect to index page
            context.Result = new RedirectToPageResult("/Index");
            
        }

        /// <summary>
        /// Method to check if current user has access to page
        /// </summary>
        /// <returns>True if user has access, else FALSE</returns>
        protected bool HasAccess()
        {
            // check if set role with access
            if (this.RoleAccess.Count > 0)
            {
                // loads user role from session
                if (this._sessionService.GetUserRole() != null)
                {
                    // check if user role has access for current page
                    if (!this.RoleAccess.Contains(this._sessionService.GetUserRole()))
                    {
                        // set error message to session
                        this._sessionService.SetErrorMessage("Přístup odepřen!");

                        return false;
                    }
                }
                else
                {
                    // set error message to session
                    this._sessionService.SetErrorMessage("Přístup odepřen!");

                    return false;
                } 
            }

            return true;
            
        }
    }
}
