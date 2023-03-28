using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace QuanLySieuThi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index([Bind(Prefix = "search")] string searchKw)
        {
            ProductBUS productBUS = new ProductBUS();
            List<Product> products = null;
            if (!searchKw.IsNullOrWhiteSpace())
                products = productBUS.GetProducts(searchKw);
            else
                products = productBUS.GetProducts();
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Product(string id)
        {
            ProductBUS productBUS = new ProductBUS();
            Product product = productBUS.GetProduct(id);
            ViewBag.Product = product;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}