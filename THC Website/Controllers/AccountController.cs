using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THC_Website.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserManagement()
        {
            return View();
        }

        public ActionResult PatientManagement()
        {
            return View();
        }
    }
}