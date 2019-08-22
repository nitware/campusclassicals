using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Web.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
                
        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        [UIHint("password")]
        [Compare("Password", ErrorMessage ="Password and it's confirmation did not match!")]
        public string RetypePassword { get; set; }

        public string Username { get; set; }
        

    }
}
