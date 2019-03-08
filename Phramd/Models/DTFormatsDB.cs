using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Models
{
    public class DTFormatsDB
    {
        public int id { get; set; }

        public string Day { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Seconds { get; set; }
        public string Time { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
