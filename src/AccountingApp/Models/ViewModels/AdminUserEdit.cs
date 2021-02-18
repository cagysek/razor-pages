using System;
using System.ComponentModel.DataAnnotations;
using AccountingApp.Models.Base;

namespace AccountingApp.Models.ViewModels
{ 
    /// <summary>
    /// ViewModel for form which admin uses for user edit
    /// extends common user properties
    /// </summary>
    public class AdminUserEdit : BaseUser
    {
        /// <summary>
        /// New user password
        /// </summary>
        [Display(Name = "Nové heslo")]
        public string NewPassword { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        public Role Role { get; set; }
    }
}
