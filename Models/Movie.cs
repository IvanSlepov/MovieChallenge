using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
        public string Year { get; set; }

    }
}