using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlZen.Model
{
    public class Weekly
    {
        public string PlaceCode { get; set; }
        public string DOW { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Stop { get; set; }
        public string What { get; set; }
        public string Who { get; set; }

        public Weekly()
        {
        }
        public Weekly(string placeCode, string dow, string start, string stop, string what, string who)
        {
            PlaceCode = placeCode;
            DOW = dow;
            Start = TimeSpan.Parse(start);
            Start = TimeSpan.Parse(stop);
            What = what;
            Who = who;
        }
    }
}
