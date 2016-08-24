using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THC_Website.Areas.Services.Controllers
{
    public class LabServicesController : Controller
    {
        // GET: Services/LabServices
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LabService1()
        {
            return View();
        }

        public ActionResult LabService2()
        {
            return View();
        }
    }
}