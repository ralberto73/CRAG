using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Models
{
    public class UserModel
    {
        [Key]
        public Guid  userId { get; set; }

        public string userEmail { get; set; }

        public bool IsActive { get; set; }
    }
}
