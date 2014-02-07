using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlZen.Model
{
    [DebuggerDisplay("{Code} - {Name}")]
    public class Place
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public Place()
        {
        }
        //public Place(string code, string name, string link)
        //{
        //    Code = code;
        //    Name = name;
        //    Link = link;
        //}
    }
}
