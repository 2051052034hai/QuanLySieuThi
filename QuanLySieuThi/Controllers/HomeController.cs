using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;
using System.Xml.Linq;

namespace QuanLySieuThi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductBUS productBUS = new ProductBUS();
            List<Product> products = productBUS.GetProducts();
            ViewBag.Products = products;
            return View();
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

        public ActionResult Products([Bind(Prefix = "id")] string id)
        {
            ProductBUS productBUS = new ProductBUS();
            List<Product> products = productBUS.GetProducts();
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}