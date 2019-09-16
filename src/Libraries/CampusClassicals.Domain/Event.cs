using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public string PostedBy { get; set; }
        public string UpdatedBy { get; set; }

        public int MediaId { get; set; }
        //public int MediaTypeId { get; set; }

        public Media Media { get; set; }
        //public MediaType MediaType { get; set; }

    }




}
