using Admin_Page.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_Page.Controllers
{
    [UserAuthenticationFilter]
    public class StoreController : Controller
    {
        // GET: Store
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View();
        }
    }
}