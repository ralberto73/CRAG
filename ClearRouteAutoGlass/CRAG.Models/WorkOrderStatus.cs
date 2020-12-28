﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRAG.Models
{
    public class WorkOrderStatus
    { 
         [Key]
        public int WorkOrderStatusId { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string WorkOrderStatusName { get; set; }

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
