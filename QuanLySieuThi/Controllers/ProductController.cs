using QuanLySieuThi.BUS;
using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;

namespace QuanLySieuThi.Controllers
{
    public class ProductController : Controller
    {
        public void getAllCategories()
        {
            CategoryBUS categoryBUS = new CategoryBUS();
            List<Category> category = categoryBUS.GetCategories();
            ViewBag.Categories = category;
        }
        // GET: ProductDetail
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Product(int id)
        {
            getAllCategories();

            ProductBUS bus = new ProductBUS();
            Product p = new Product();
            p = bus.GetProduct(id);
            ViewBag.product = p;
            return View();
        }
    }
}