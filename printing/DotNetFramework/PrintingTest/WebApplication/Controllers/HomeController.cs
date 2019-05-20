using System;
using System.Drawing.Printing;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexModel indexModel = new IndexModel();

            try
            {
                foreach (var printer in PrinterSettings.InstalledPrinters)
                {
                    indexModel.Printers.Add(printer.ToString());
                }
            }
            catch(Exception ex)
            {
                indexModel.ErrorMessage = ex.Message;
            }

            return View(indexModel);
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