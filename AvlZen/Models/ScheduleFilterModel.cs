using AvlZen.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvlZen.Models
{
    [DebuggerDisplay("{DOW}")]
    public class ScheduleFilterModel
    {
        public string DOW { get; set; }
        public IEnumerable<PlaceSelectionModel> SelectionPlaces { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Weekly> Classes { get; set; }
        public SelectList DaysList { get; set; }

        public void Init()
        {
            if (this.DaysList==null)
                this.DaysList = new SelectList(Enum.GetNames(typeof(DayOfWeek)), this.DOW);

            if(this.DOW == null)
                this.DOW = DateTime.Today.DayOfWeek.ToString();

            if (this.Places==null)
                this.Places = ExcelReader.GetPlaces(Utils.ExcelFileName);

            if (this.SelectionPlaces==null)
                this.SelectionPlaces = this.Places.OrderBy(p => p.Code).Select(p => new PlaceSelectionModel { IsSelected = true, PlaceCode = p.Code }).AsEnumerable();

            var placeList = this.Places.ToArray();
            var getPlaces = new List<string>();
            int i = 0;
            foreach (var sel in this.SelectionPlaces)
            {
                sel.PlaceCode = placeList[i].Code; //HACK: 
                if (sel.IsSelected)
                    getPlaces.Add(sel.PlaceCode);
                ++i;
            }

            this.Classes = ExcelReader.GetDayWeeklies(Utils.ExcelFileName,
                this.DOW, getPlaces.ToArray());
        }
    }
}
