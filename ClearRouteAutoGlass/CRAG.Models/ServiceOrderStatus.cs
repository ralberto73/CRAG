using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBusiness.Models
{
    public class ServiceOrderStatus
    {
        [Key]
     
        public int ServiceOrderStatusId { get; set; }
        [Required]
        [Display(Name = "Status Name")]
        public string StatusName { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Icon")]
        public string IconPicture { get; set; }

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
