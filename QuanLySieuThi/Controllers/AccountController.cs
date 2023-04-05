using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;
using QuanLySieuThi.Controllers;
namespace QuanLySieuThi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(int id)
        {
            CustomerDAO cusDAO = new CustomerDAO();
            Customer cus = cusDAO.ViewDetail(id);
            ViewBag.Username = cus.UserName;
            ViewBag.FullName = cus.CustomerName;
            ViewBag.Phone = cus.CustomerPhone;
            ViewBag.Address = cus.CustomerAddress;
            ViewBag.Password = cus.Password;
            ViewBag.ID = cus.CustomerID;
            return View(cus);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            string ID = Request.Form["ID"];
            string fullname = Request.Form["fullname"];
            string phone = Request.Form["phone"];
            string adress = Request.Form["address"];
            string password = Request.Form["password"];

            Customer cus = new Customer();
            CustomerDAO dao = new CustomerDAO();
            cus = dao.GetCustomerById(Int32.Parse(ID));
            dao.UpdateInfo(cus, fullname, phone, adress, password);
           
            return RedirectToAction("Index", "Home");
        }
    }
}