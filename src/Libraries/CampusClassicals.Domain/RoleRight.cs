using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class RoleRight : BaseEntity
    {
        public int RoleId { get; set; }
        public int RightId { get; set; }

        public Role Role { get; set; }
        public Right Right { get; set; }

    }
}
