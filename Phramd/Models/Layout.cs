using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramd.Models
{
    public class Layout
    {
        public int id { get; set; }

        public decimal calX { get; set; }
        public decimal calY { get; set; }
        public decimal calW { get; set; }
        public decimal calH { get; set; }

        public decimal weathX { get; set; }
        public decimal weathY { get; set; }
        public decimal weathW { get; set; }
        public decimal weathH { get; set; }

        public decimal newsX { get; set; }
        public decimal newsY { get; set; }
        public decimal newsW { get; set; }
        public decimal newsH { get; set; }

        public decimal dateX { get; set; }
        public decimal dateY { get; set; }
        public decimal dateW { get; set; }
        public decimal dateH { get; set; }

        public decimal timeX { get; set; }
        public decimal timeY { get; set; }
        public decimal timeW { get; set; }
        public decimal timeH { get; set; }

        public DateTime layoutadded { get; set; }
        public DateTime layoutremoved { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
