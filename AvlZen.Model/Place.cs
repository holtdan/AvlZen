using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlZen.Model
{
    [DebuggerDisplay("{PlaceID}.{Code} - {Name}")]
    public class Place
    {
        public int PlaceID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Address { get; set; }

        public Place()
        {
        }
    }
}
