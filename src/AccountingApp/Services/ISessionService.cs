using System;
using AccountingApp.Models;

namespace AccountingApp.Services
{
    /// <summary>
    /// Interface for session service
    /// </summary>
    public interface ISessionService
    {
        public void LogUser(AppUser User);

        public void LogoutUser();

        public float? GetUserId();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>string</returns>
        public string GetUserRole();

        public void SetErrorMessage(string msg);

        public string GetErrorMessage();
    }
}
