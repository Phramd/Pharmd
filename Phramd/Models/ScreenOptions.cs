using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Models
{
    public class ScreenOptions
    {
        public int id { get; set; }

        public string screensize { get; set; }

        public string screenlayout { get; set; }

        public DateTime optionsadded { get; set; }

        public DateTime optionsremoved { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
