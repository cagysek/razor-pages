using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingApp.Models
{
    /// <summary>
    /// Model for invoice item
    /// </summary>
    public class InvoiceItem
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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Invoice key
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Price DPH
        /// </summary>
        [Display(Name = "Cena s DPH")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [Required]
        public float PriceDph { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Display(Name = "Cena")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [Required]
        public float Price { get; set; }

        /// <summary>
        /// Tax value
        /// </summary>
        [Display(Name = "DPH")]
        [Required]
        public int PriceVat { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Display(Name = "Počet")]
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Final price
        /// </summary>
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public float TotalPriceDph
        {
            get { return Quantity * PriceDph; }
        }
    }
}
