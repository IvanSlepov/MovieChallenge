using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Rent
    {
        public int RentID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}