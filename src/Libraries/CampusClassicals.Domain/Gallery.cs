using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class Gallery : BaseEntity
    {
        public string Title { get; set; }
        public string Short { get; set; }
        public string Full { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        //public int MediaId { get; set; }
        public int CreatedById { get; set; }
        public int? UpdatedById { get; set; }

        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        //public Media Media { get; set; }

    }



}
