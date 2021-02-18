using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingApp.Models.ViewModels
{
    /// <summary>
    /// ViewModel for change user password
    /// extends common user properties
    /// </summary>
    public class PasswordChange
    {
        /// <summary>
        /// Old password
        /// </summary>
        [Display(Name = "Straré heslo")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string OldPassword { get; set; }

        /// <summary>
        /// New password
        /// </summary>
        [Display(Name = "Nové heslo")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Confirm new password
        /// </summary>
        [Display(Name = "Potvrzení hesla")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string ConfirmPassword { get; set; }
    }
}
