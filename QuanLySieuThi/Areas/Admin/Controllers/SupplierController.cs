using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.BUS;
using QuanLySieuThi.DTO;
namespace QuanLySieuThi.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            SupplierBUS supplierBUS = new SupplierBUS();
            ViewBag.Suppliers=supplierBUS.GetSupplliers();
            return View();
        }

        public ActionResult EditSupplierIndex(int id)
        {
            SupplierBUS supplierBUS = new SupplierBUS();
            Supplier supp = supplierBUS.GetSupplierById(id);
            ViewBag.Supplier = supp;
            return View(supp);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            string ID = Request.Form["ID"];
            string Name = Request.Form["Name"];
            string Description = Request.Form["Description"];
            SupplierBUS supplierBUS = new SupplierBUS();
            Supplier supp = new Supplier();
            supp = supplierBUS.GetSupplierById(Int32.Parse(ID));
            supplierBUS.UpdateInfo(supp, Name, Description);
            return RedirectToAction("Index", "Supplier");
        }
        public ActionResult Delete(int id)
        {
            SupplierBUS supplierBUS = new SupplierBUS();
            supplierBUS.Delete(id);
            return RedirectToAction("Index", "Supplier");
        }
        public ActionResult AddSupplierIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            string Name = Request.Form["Name"];
            string Description = Request.Form["Description"];
            SupplierBUS supplierBUS = new SupplierBUS();
            Supplier supp = new Supplier(Name, Description);
            supplierBUS.Create(supp);
            return RedirectToAction("Index", "Supplier");
        }
    }
}
