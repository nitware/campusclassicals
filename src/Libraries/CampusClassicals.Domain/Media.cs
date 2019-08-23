using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    public class Media : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public byte[] File { get; set; }
        public string MimeType { get; set; }

        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }



        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Url { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }

        //public int MediaTypeId { get; set; }
        //public int CreatedById { get; set; }

        //public MediaType MediaType { get; set; }
        //public User CreatedBy { get; set; }
    }






}
