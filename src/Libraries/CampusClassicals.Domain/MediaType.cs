using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class MediaType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
