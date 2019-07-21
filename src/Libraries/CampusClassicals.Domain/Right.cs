using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class Right : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<RoleRight> RoleRights { get; set; }
    }


}
