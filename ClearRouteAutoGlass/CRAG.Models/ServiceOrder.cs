using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Models
{
    public class ServiceOrder
    {
        [Key]
        public long  ServiceOrderId{ get; set; }
        public int ServiceOrderStatusId { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } 

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string SubModel { get; set; }
        public int Year        { get; set; }

        [Display(Name = "Part")]
        public int ProductId { get; set; }
        public string PaymentMethod { get; set; }

        [Display(Name = "Insurance")]
        public int InsuranceId { get; set; }

        public int SupplierId { get; set; }
        public decimal BillableAmount { get; set; }
        public decimal LaborAmount { get; set; }
        public decimal PartCost { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
/*

 */