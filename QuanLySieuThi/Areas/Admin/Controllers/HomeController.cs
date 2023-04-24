using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.BUS;
namespace QuanLySieuThi.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ProductBUS productBUS = new ProductBUS();
            ViewBag.Products = productBUS.GetProducts();
            return View();
        }
    }
}