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
using QuanLySieuThi.Filter;

namespace QuanLySieuThi.Controllers
{
    [AddCategoriesFilter]
    public class HomeController : Controller
    {
        public ActionResult Index([Bind(Prefix = "search")] string searchKw, [Bind(Prefix = "categoryId")] string categoryId)
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

        //public ActionResult Product(string id)
        //{
        //    ProductBUS productBUS = new ProductBUS();
        //    Product product = productBUS.GetProduct(id);
        //    ViewBag.Product = product;
        //    return View();
        //}

        public ActionResult Category(string id)
        {
            ProductBUS productBUS = new ProductBUS();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("categoryId", id);
            List<Product> products = productBUS.GetProducts(queryParams);
            ViewBag.Products = products;
            return View();
        }
    }
}
