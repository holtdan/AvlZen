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
            var cookie = Request.Cookies["selStudios"];

            var vm = new ScheduleFilterModel();
            vm.Init(cookie != null?cookie.Value:null);

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(ScheduleFilterModel model)
        {
            model.Init(null);

            var sels = from sp in model.SelectionPlaces
                       where sp.IsSelected
                       select sp.Code;
            var selStr = string.Join(",", sels);
            HttpCookie stdsCook = new HttpCookie("selStudios", selStr)
            {
                Expires = DateTime.Now.AddDays(5)
            };
            Response.AppendCookie(stdsCook);
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
