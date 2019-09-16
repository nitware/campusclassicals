using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class Media : BaseEntity
    {
        public byte[] File { get; set; }
        public string Url { get; set; }

    }






}
