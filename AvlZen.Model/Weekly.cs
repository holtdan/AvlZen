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
        public int ID { get; set; }
        public int PlaceID { get; set; }
        public string PlaceCode { get; set; }
        public string DOW { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string What { get; set; }
        public string Who { get; set; }

        public Weekly()
        {
        }
        public Weekly(string placeCode, string dow, string start, string stop, string what, string who)
        {
            PlaceCode = placeCode;
            DOW = dow;
            Start = DateTime.Parse(start);
            Start = DateTime.Parse(stop);
            What = what;
            Who = who;
        }
    }
}
