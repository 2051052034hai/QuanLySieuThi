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

        // Hàm Lấy loại sẩn phẩm từ cơ sở dữ liệu
        public void getAllCategories()
        {
            CategoryBUS categoryBUS = new CategoryBUS();
            List<Category> category = categoryBUS.GetCategories();
            ViewBag.Categories = category;
        }
        public ActionResult Index([Bind(Prefix = "search")] string searchKw)
        {
            ProductBUS productBUS = new ProductBUS();
            List<Product> products = null;
            if (!searchKw.IsNullOrWhiteSpace())
                products = productBUS.GetProducts(searchKw);
            else
                products = productBUS.GetProducts();
            ViewBag.Products = products;

            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();
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
            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();
            return View();
        }

        public ActionResult Register()
        {
            // Lấy loại sẩn phẩm từ cơ sở dữ liệu
            getAllCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(string username, string email, string phone, string password)
        {
            var cus = new Customer
            (
                username,
                email,
                phone,
                password
            );

            Console.WriteLine(cus);

            // Thêm đối tượng Customer vào CSDL
            CustomerDAO dao = new CustomerDAO();
            dao.Create(cus);

            return RedirectToAction("Login", "home");
        }

    }
}
