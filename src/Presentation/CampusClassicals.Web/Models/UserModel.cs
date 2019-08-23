using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Web.Models
{
    public class UserModel : UrlModel
    {
        [Required]
        public string Name { get; set; }
                
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
       
        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        [UIHint("password")]
        [Compare("Password", ErrorMessage ="Password and it's confirmation did not match!")]
        public string RetypePassword { get; set; }

        public string Username { get; set; }

        public bool IAgree { get; set; }


    }
}
