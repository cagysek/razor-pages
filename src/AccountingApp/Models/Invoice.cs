using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingApp.Models
{
    /// <summary>
    /// Enum for invoice state
    /// </summary>
    public enum InvoiceType
    {
        [Display(Name = "Přijatá")]
        ACCEPTED = 1,
        [Display(Name = "Vydaná")]
        PUBLISHED = 2
    }

    /// <summary>
    /// Model for invoice
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Invoice ID
        /// </summary>
        [Display(Name = "Číslo faktury")]
        public int ID { get; set; }

        /// <summary>
        /// Supplier company
        /// </summary>
        [Display(Name = "Dodavatel")]
        public Company Suppliercompany { get; set; }

        /// <summary>
        /// Billing company
        /// </summary>
        [Display(Name = "Odběratel")]
        public Company BillToCompany { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [Display(Name = "Datum vytvoření")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string PublishDate { get; set; }

        /// <summary>
        /// Payment type
        /// </summary>
        [Display(Name = "Datum splatnost")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string PaymentDate { get; set; }

        /// <summary>
        ///  Taxable suppply date
        /// </summary>
        [Display(Name = "Datum zdan. plnění")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} nesmí být prázdné")]
        public string TaxableSupplyDate { get; set; }

        /// <summary>
        /// Is storno
        /// </summary>
        [Display(Name = "Stornováno")]
        public Boolean IsStorno { get; set; }

        /// <summary>
        /// Invoice items
        /// </summary>
        public List<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Invoice type
        /// </summary>
        [EnumDataType(typeof(InvoiceType))]
        [Display(Name = "Typ faktury")]
        public InvoiceType Type { get; set; }

        /// <summary>
        /// Final price with dph
        /// not mapped to query
        /// </summary>
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public float TotalPriceDph
        {
            get {

                if (InvoiceItems == null)
                {
                    return 0;
                }

                float totalPriceDph = 0;

                foreach (InvoiceItem item in InvoiceItems)
                {
                    totalPriceDph += (item.PriceDph * item.Quantity);
                }

                return totalPriceDph;
            }
        }

        /// <summary>
        /// final price without dph
        /// not mapped to query
        /// </summary>
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public float TotalPrice
        {
            get
            {
                if (InvoiceItems == null)
                {
                    return 0;
                }

                float totalPrice = 0;

                foreach (InvoiceItem item in InvoiceItems)
                {
                    totalPrice += (item.Price * item.Quantity);
                }

                return totalPrice;
            }
        }

    }
}
