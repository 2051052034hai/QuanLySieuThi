﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.BUS;
using QuanLySieuThi.DTO;

namespace QuanLySieuThi.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Areas/ProductsList
        public ActionResult Index()
        {
            ProductBUS bus = new ProductBUS();
            ViewBag.Products = bus.GetProducts();
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
            string ID = Request.Form["ID"];
            string Name = Request.Form["Name"];
            string UnitPrice = Request.Form["UnitPrice"];
            string UnitInStock = Request.Form["UnitInStock"];
            string CateID = Request.Form["CateID"];
            string Description = Request.Form["Description"];
            string SuppilerID = Request.Form["SuppilerID"];
            string Image_Url = Request.Form["Image_Url"];
            Product prod = new Product();
            ProductBUS productBUS = new ProductBUS();
            prod = productBUS.GetProduct(Int32.Parse(ID));
            productBUS.UpdateProductInfo(prod, Name, UnitPrice, UnitInStock, CateID, Description, SuppilerID, Image_Url);

            return RedirectToAction("Index", "Product");
        }
        public ActionResult Delete(int id)
        {
            ProductBUS productBUS = new ProductBUS();
            productBUS.Delete(id);
            return RedirectToAction("Index", "Product");
        }
        public ActionResult AddProductIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add()
        {
            string Name = Request.Form["Name"];
            string UnitPrice = Request.Form["UnitPrice"];
            string UnitInStock = Request.Form["UnitInStock"];
            string CateID = Request.Form["CateID"];
            string Description = Request.Form["Description"];
            string SuppilerID = Request.Form["SuppilerID"];
            string Image_Url = Request.Form["Image_Url"];
            Product prod = new Product(Name, UnitPrice, UnitInStock, CateID, SuppilerID, Description, Image_Url);
            ProductBUS productBUS = new ProductBUS();

            productBUS.Add(prod);
            return RedirectToAction("Index", "Product");
        }
    }
}