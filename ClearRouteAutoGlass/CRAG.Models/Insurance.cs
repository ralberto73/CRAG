using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBusiness.Models
{
    public partial class Insurance
    {
        [Key]
        [Display(Name = "Id")]
        public int InsuranceId { get; set; }
        [Required]
        [Display(Name = "Insurance")]
        public string InsuranceName { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Last Update")]
        public DateTime LastUpdateDate { get; set; }
    }
}
