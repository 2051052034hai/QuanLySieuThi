using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.BUS;
using QuanLySieuThi.Controllers;
using QuanLySieuThi.DAO;
using QuanLySieuThi.DTO;

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
            ProductBUS bus = new ProductBUS();
            ViewBag.Products=bus.GetProducts();
            
            return View();
        }
        public ActionResult EditProductIndex(int id)
        {
            ProductBUS bus = new ProductBUS();
            Product prod = bus.GetProduct(id);
            ViewBag.Product = prod;
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            string ProductID = Request.Form["ProductID"];
            string ProductName = Request.Form["ProductName"];
            string UnitPrice = Request.Form["UnitPrice"];
            string UnitInStock = Request.Form["UnitInStock"];
            string CateID = Request.Form["CateID"];
            string Description = Request.Form["Description"];
            string SuppilerID = Request.Form["SuppilerID"];
            string Image_Url = Request.Form["Image_Url"];
            Product prod = new Product();
            ProductDAO dao = new ProductDAO();
            prod = dao.GetProductById(Int32.Parse(ProductID));
            dao.UpdateInfo(prod, ProductName, UnitPrice, UnitInStock, CateID, Description, SuppilerID, Image_Url);

            return RedirectToAction("ProductIndex", "ProductsList");
        }
        public ActionResult Delete(int id)
        {
            ProductDAO dao = new ProductDAO();
            dao.DeleteProduct(id);
            return RedirectToAction("ProductIndex", "ProductsList");
        }
        public ActionResult AddProductIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add()
        {
            string ProductID = Request.Form["ProductID"];
            string ProductName = Request.Form["ProductName"];
            string UnitPrice = Request.Form["UnitPrice"];
            string UnitInStock = Request.Form["UnitInStock"];
            string CateID = Request.Form["CateID"];
            string Description = Request.Form["Description"];
            string SuppilerID = Request.Form["SuppilerID"];
            string Image_Url = Request.Form["Image_Url"];
            Product prod = new Product(ProductName, UnitPrice, UnitInStock, CateID, SuppilerID, Description, Image_Url);
            ProductDAO dao = new ProductDAO();
            
            dao.Create(prod);
            return RedirectToAction("ProductIndex", "ProductsList");
        }
    }
}