using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiLab.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string descript { get; set; }
        public string rating { get; set; }
        public string mainactor { get; set; }
        public string director { get; set; }


    }
}
