using AvlZen.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            //ViewBag.Message = "Your contact page.";
            var vm = new ContactFormModel();
            vm.Init();

            return View(vm);
        }
        [HttpPost]
        public ActionResult Contact(ContactFormModel model)
        {
            //string Text = "<html> <head> </head>" +
            //" <body style= \" font-size:12px; font-family: Arial\">" +
            //Model.Message +
            //"</body></html>";

            SendEmail(model);

            var vm = new ContactFormModel();
            vm.Init();
            ModelState.Clear();
            return View(vm);
        }
        public static bool SendEmail(ContactFormModel model)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("info@avlzen.com");
            msg.To.Add(new MailAddress("info@avlzen.com"));
            msg.Subject = "AVL Zen Contact";
            msg.Body = string.Format("{0},{1}\n{2}", model.Name, model.Email, model.Message);
            msg.Priority = MailPriority.Normal;

            var client = new SmtpClient("mail.avlzen.com");
            

            client.UseDefaultCredentials = false;
            //client.EnableSsl = false;
            client.Credentials = new NetworkCredential("info@avlzen.com", "avzinfo14");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.EnableSsl = true;

            try
            {
                client.Send(msg);
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }
    }
}
