using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBusiness.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        public int ProdCategoryId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

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


