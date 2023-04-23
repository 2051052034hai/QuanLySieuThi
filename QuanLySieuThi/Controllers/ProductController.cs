using QuanLySieuThi.BUS;
using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.Filter;

namespace QuanLySieuThi.Controllers
{
    [CommonAttributeFilter]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int id)
        {
            ProductBUS bus = new ProductBUS();
            EventBUS eventBUS = new EventBUS();
            Event evt = eventBUS.GetCurrentEvent();
            Product p = bus.GetProduct(id);
            ViewBag.product = p;
            if (evt != null)
            {
                EventDetail detail = evt.EventDetails.FirstOrDefault(d => d.ProductID == p.ID);
                if (detail != null)
                {
                    ViewBag.eventDetail = detail;
                }
            }
            return View();
        }
    }
}