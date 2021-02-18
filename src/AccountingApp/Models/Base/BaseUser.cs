using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingApp.Models.Base
{
    /// <summary>
    /// Base object for user. Contains common properties for classes
    /// </summary>
    public class BaseUser
    {
        /// <summary>
        /// User ID
        /// </summary>
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        [Display(Name = "Křestní jméno")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        [Display(Name = "Příjmení")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string LastName { get; set; }

        /// <summary>
        /// Identification number
        /// </summary>
        [Display(Name = "Rodné číslo")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [RegularExpression("^\\s*(\\d\\d)(\\d\\d)(\\d\\d)[ /]*(\\d\\d\\d)(\\d?)\\s*$", ErrorMessage = "Rodné číslo není ve správném formátu (vzor: 123456/1111)")]
        public string PersonalIdentificationNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [EmailAddress(ErrorMessage = "Emailová adresa není ve správném formátu (vzor: example@email.com)")]
        public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Display(Name = "Telefonní číslo")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [RegularExpression("^(\\+420|\\+421) ?[0-9]{3} ?[0-9]{3} ?[0-9]{3}$", ErrorMessage = "Telefoní číslo není ve správněm tvaru. (Číslo musí být s předvolbou)")]
        public string Phone { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [Display(Name = "Číslo účtu")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [RegularExpression("^\\s*(\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d)([\\w ]{1})?[ /]*([\\w ]{1})?(\\d\\d\\d\\d)\\s*$", ErrorMessage = "Číslo účtu není ve správném formátu (vzor: 123456789/1111)")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Card number
        /// </summary>
        [Display(Name = "Číslo karty")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        [RegularExpression("^\\s*(\\d\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d\\d)([\\w ]{1})?(\\d\\d\\d\\d)\\s*$", ErrorMessage = "Nesprávný formát čísla karty. Velikost je 16 čísel")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [Display(Name = "Přezdívka")]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string UserName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public Address Address { get; set; }
    }
}
