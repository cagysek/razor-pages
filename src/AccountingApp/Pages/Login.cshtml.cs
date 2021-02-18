using System;
using System.Linq;
using AccountingApp.Enum;
using AccountingApp.Models;
using AccountingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AccountingApp.Pages
{
    /// <summary>
    /// PageModel for log in user
    /// </summary>
    public class LoginModel : PageModel
    {
        /// <summary>
        /// Binded property of user
        /// </summary>
        [BindProperty]
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Session service
        /// </summary>
        private ISessionService _sessionService { get; }

        /// <summary>
        /// Binded property for view. Contains error message if login has error
        /// </summary>
        public String ErrMsg;

        /// <summary>
        /// Database contexxt
        /// </summary>
        readonly DatabaseContext _context;

        public LoginModel(DatabaseContext context, ISessionService sessionService)
        {
            this._context = context;
            _sessionService = sessionService;
        }

        /// <summary>
        /// POST action. Proccess login form
        /// </summary>
        /// <returns>Index page if login is sucessful, else login form with error</returns>
        public IActionResult OnPost()
        {
            
            var user = CheckCredentials(AppUser.UserName, AppUser.Password);
            
            if (user == null)
            {
                TempData[EFlashMessage.Error] = "Špatně zadané jméno nebo heslo";
                return Page();
            }

            _sessionService.LogUser(user);

            return RedirectToPage("Index");
        }

        /// <summary>
        /// Checks user credentials
        /// </summary>
        /// <param name="username">Given username</param>
        /// <param name="password">Given password</param>
        /// <returns>Object AppUser if exits, else NULL</returns>
        private AppUser CheckCredentials(String username, String password)
        {
            // try to find user by username
            var user = _context.AppUser
                                    .Include(a => a.Role)
                                    .SingleOrDefault(a => a.UserName.Equals(username));
            
            if (user != null)
            {
                // verify user password vs given password
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }

            return null;
        }
    }
}
