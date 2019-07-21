using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateEntered { get; set; }
        public bool IsLocked { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
       
    }



}
