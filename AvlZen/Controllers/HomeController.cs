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
            vm.Init();

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(ScheduleFilterModel model)
        {
            model.Init();

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
