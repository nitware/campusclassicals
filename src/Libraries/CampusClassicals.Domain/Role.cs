using System.Collections.Generic;

namespace CampusClassicals.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<RoleRight> RoleRights { get; set; }
    }



}