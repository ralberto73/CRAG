using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRAG.Models
{
    public class ApplicationUser :  IdentityUser
    {
        [Required]
        public string  Name { get; set; }

        public string Address_Line1 { get; set; }

        public string Address_Line2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
