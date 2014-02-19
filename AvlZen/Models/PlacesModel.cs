using AvlZen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvlZen.Models
{
    public class PlacesModel
    {
        public IEnumerable<Place> Places { get; set; }

        public void Init()
        {
            if (this.Places == null)
                this.Places = ExcelReader.GetPlaces(Utils.ExcelFileName);
        }
    }
}
