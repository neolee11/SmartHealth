using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THC_Website.Areas.Services.Controllers
{
    public class ClientServicesController : Controller
    {
        // GET: Services/ClientServices
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookAppoinment()
        {
            return View();
        }
        
    }
}