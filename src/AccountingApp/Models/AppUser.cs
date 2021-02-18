using System.ComponentModel.DataAnnotations;
using AccountingApp.Models.Base;

namespace AccountingApp.Models
{
    /// <summary>
    /// Model for user
    /// </summary>
    public class AppUser : BaseUser
    {
        /// <summary>
        /// Password
        /// </summary>
        [Display(Name = "Heslo")]
        [Required(ErrorMessage = "{0} nesmí být prázdná")]
        public string Password { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public Role Role { get; set; }
    }
}
