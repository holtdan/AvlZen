using AvlZen.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AvlZen.Models
{
    [DebuggerDisplay("{DOW}")]
    public class ScheduleFilterModel
    {
        public string DOW { get; set; }
        public IEnumerable<PlaceSelectionModel> SelectionPlaces { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Weekly> Classes { get; set; }
    }
}
