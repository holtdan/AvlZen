using AvlZen.Model;
using AvlZen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvlZen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new ScheduleFilterModel();
            vm.DOW = DayOfWeek.Tuesday.ToString();// DateTime.Today.DayOfWeek.ToString();
            vm.Places = ExcelReader.GetPlaces(@"c:\users\daniel holt\documents\visual studio 2013\Projects\AvlZen\AvlZen\App_Data\AvlZen.xlsx");

            vm.SelectionPlaces = vm.Places.OrderBy(p=>p.Code).Select(p => new PlaceSelectionModel { IsSelected = true, PlaceCode = p.Code }).AsEnumerable();
            vm.Classes = ExcelReader.GetDayWeeklies(@"c:\users\daniel holt\documents\visual studio 2013\Projects\AvlZen\AvlZen\App_Data\AvlZen.xlsx",
                vm.DOW, "AvlComYog", "WstAvlYog");
            TempData["Huh"] = "A";

            ViewData["dows"] = new SelectList(Enum.GetNames(typeof(DayOfWeek)),vm.DOW);

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(ScheduleFilterModel model)
        {
            var vd = ViewData;
            var x = this.Request;
            var y = this.Response;
            var z = this.ViewBag;
            if (TempData["Huh"] != null)
            {
                var h = TempData["Huh"];
            }

            model.Places = ExcelReader.GetPlaces(@"c:\users\daniel holt\documents\visual studio 2013\Projects\AvlZen\AvlZen\App_Data\AvlZen.xlsx");
            var getPlaces = new List<string>();
            var placeList = model.Places.ToArray();
            int i = 0;
            foreach ( var sel in model.SelectionPlaces)
            {
                if ( sel.IsSelected )
                    getPlaces.Add(placeList[i].Code);
                ++i;
            }
            //model.SelectionPlaces = vm.Places.Select(p => new PlaceSelectionModel { IsSelected = true, PlaceCode = p.Code }).AsEnumerable();
            model.Classes = ExcelReader.GetDayWeeklies(@"c:\users\daniel holt\documents\visual studio 2013\Projects\AvlZen\AvlZen\App_Data\AvlZen.xlsx",
                model.DOW, getPlaces.ToArray());
            TempData["Huh"] = "A";

            ViewData["dows"] = new SelectList(Enum.GetNames(typeof(DayOfWeek)), model.DOW);

            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
