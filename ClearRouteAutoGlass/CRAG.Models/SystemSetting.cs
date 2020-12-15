using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRAG.Models
{
    public class SystemSetting
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="Key")]
        public int Key { get; set; }

        [Display(Name = "Value")]
        public int Value  { get; set; }
    }
}
