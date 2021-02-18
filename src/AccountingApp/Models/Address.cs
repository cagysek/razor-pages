using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingApp.Models
{
    /// <summary>
    /// Model represents address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// ID of address
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zip code, allow null value
        /// </summary>
        [RegularExpression("^\\s*(\\d\\d\\d)([\\w ]{1})?(\\d\\d)\\s*$", ErrorMessage = "PSČ je ve špatném formátu (vzor: 301 00)")]
        public System.Nullable<int> ZipCode { get; set; }
    }
}
