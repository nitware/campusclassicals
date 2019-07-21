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
        public DateTime Date { get; set; }

        //public int PostedById { get; set; }
        public int MediaId { get; set; }
      
        public Media Media { get; set; }
        //public User PostedBy { get; set; }
    }




}
