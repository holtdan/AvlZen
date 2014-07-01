using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlZen.Model
{
    public class DbReader
    {
        public static IList<Place> GetPlaces()
        {
            using (var dc = new AvlZenContext())
            {
                return dc.Places.ToList();
            }
        }
    }
}
