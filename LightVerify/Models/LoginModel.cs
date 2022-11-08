using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightVerify.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
