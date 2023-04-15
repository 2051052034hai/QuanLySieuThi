using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySieuThi.Areas.Areas.Controllers
{
    public class ProductsListController : Controller
    {
        // GET: Areas/ProductsList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductIndex()
        {
            return View();
        }

    }
}