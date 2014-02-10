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
        public IList<PlaceSelectionModel> SelectionPlaces { get; set; }
        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Weekly> Classes { get; set; }
        public SelectList DaysList { get; set; }

        public void Init(string useStds)
        {
            if (this.DaysList == null)
                this.DaysList = new SelectList(Enum.GetNames(typeof(DayOfWeek)), this.DOW);

            if (this.DOW == null)
                this.DOW = DateTime.Today.DayOfWeek.ToString();

            if (this.Places == null)
                this.Places = ExcelReader.GetPlaces(Utils.ExcelFileName);

            var stdList = useStds != null ? useStds.Split(',') : new string[] { };
            if (this.SelectionPlaces == null)
                this.SelectionPlaces = this.Places.OrderBy(p => p.Code).Select(p =>
                    new PlaceSelectionModel
                    {
                        IsSelected = useStds != null && stdList.Contains(p.Code) ? true : useStds == null ? true : false,
                        Place = p.Name,
                        Code = p.Code
                    }).ToList();

            var placeList = this.Places.ToArray();
            var getPlaces = new List<string>();
            int i = 0;
            foreach (var sel in this.SelectionPlaces)
            {
                sel.Place = placeList[i].Name; //HACK: 
                sel.Code = placeList[i].Code; //HACK: 
                if (sel.IsSelected)
                    getPlaces.Add(sel.Code);
                ++i;
            }

            this.Classes = ExcelReader.GetDayWeeklies(Utils.ExcelFileName,
                this.DOW, getPlaces.ToArray());
        }
    }
}
