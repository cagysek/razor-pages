using System;
using AccountingApp.Models;
using Microsoft.AspNetCore.Http;

namespace AccountingApp.Services
{
    /// <summary>
    /// Service for work with session
    /// </summary>
    public class SessionService : ISessionService
    {
        /// <summary>
        /// HttpContext
        /// </summary>
        private readonly HttpContext httpContext;

        /// <summary>
        /// Property username
        /// </summary>
        public static readonly string USERNAME = "username";

        /// <summary>
        /// Property is user logged
        /// </summary>
        public static readonly string LOGGED = "loged";

        /// <summary>
        /// Property user role
        /// </summary>
        public static readonly string ROLE = "role";

        /// <summary>
        /// Property user id
        /// </summary>
        public static readonly string ID = "userId";

        /// <summary>
        /// Property error message
        /// </summary>
        public static readonly string ERR_MSG = "error_msg";



        public SessionService(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext.HttpContext;
        }

        /// <summary>
        /// Set up session for logged user
        /// </summary>
        /// <param name="user"></param>
        public void LogUser(AppUser user)
        {
            this.httpContext.Session.SetInt32(ID, user.Id);
            this.httpContext.Session.SetString(USERNAME, user.UserName);
            this.httpContext.Session.SetInt32(LOGGED, 1);
            this.httpContext.Session.SetString(ROLE, user.Role.Name);
        }

        /// <summary>
        /// Destroy user's session
        /// </summary>
        public void LogoutUser()
        {
            this.httpContext.Session.Clear();
        }

        /// <summary>
        /// Get user ID
        /// </summary>
        /// <returns>User's ID if is set, else NULL</returns>
        public float? GetUserId()
        {
            return this.httpContext.Session.GetInt32(ID);
        }

        /// <summary>
        /// Get user ROLE
        /// </summary>
        /// <returns>User's role if is set, else NULL</returns>
        public string GetUserRole()
        {
            return this.httpContext.Session.GetString(ROLE);
        }

        /// <summary>
        /// Set up error message to session
        /// </summary>
        /// <param name="message">Error message text</param>
        public void SetErrorMessage(string message)
        {
            this.httpContext.Session.SetString(ERR_MSG, message);
        }

        /// <summary>
        /// Get Error message
        /// </summary>
        /// <returns>Error message if is set, else NULL</returns>
        public string GetErrorMessage()
        {
            string msg = this.httpContext.Session.GetString(ERR_MSG);

            this.httpContext.Session.Remove(ERR_MSG);

            return msg;
        }
    }
}
