using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingApp.Models
{
    /// <summary>
    /// Model for company
    /// </summary>
    public class Company
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Display(Name = "Název")]
        [Required(ErrorMessage = "{0} nesmí být prázdný")]
        public string Title { get; set; }

        /// <summary>
        /// IČ
        /// </summary>
        [Display(Name = "IČ")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public int Ic { get; set; }

        /// <summary>
        /// DIČ
        /// </summary>
        [Display(Name = "DIČ")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string Dic { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Display(Name = "Telefonní číslo")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [RegularExpression("^(\\+420|\\+421) ?[0-9]{3} ?[0-9]{3} ?[0-9]{3}$", ErrorMessage = "Telefoní číslo není ve správněm tvaru. (Číslo musí být s předvolbou)")]
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Emailová adresa není ve správném formátu (vzor: example@email.com)")]
        public string Email { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [Display(Name = "Číslo účtu")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [RegularExpression("^\\s*(\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d)([\\w ]{1})?[ /]*([\\w ]{1})?(\\d\\d\\d\\d)\\s*$", ErrorMessage = "Číslo účtu není ve správném formátu (vzor: 123456789/1111)")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public Address Address { get; set; }

    }
}
