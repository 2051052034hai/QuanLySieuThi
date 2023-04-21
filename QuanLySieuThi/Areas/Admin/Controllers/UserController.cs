using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLySieuThi.DTO;
using QuanLySieuThi.BUS;
using System.Web.Mvc;

namespace QuanLySieuThi.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            EmployeeBUS employeeBUS = new EmployeeBUS();
            ViewBag.Employees = employeeBUS.GetAllEmployees();
            return View();
        }

        public ActionResult EditUsersIndex(int id)
        {
            EmployeeBUS employeeBUS = new EmployeeBUS();
            Employee emp = employeeBUS.GetEmployeeById(id);
            ViewBag.Employee = emp;

            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            string ID = Request.Form["ID"];
            string name = Request.Form["name"];
            string phone = Request.Form["phone"];
            string adress = Request.Form["address"];
            string password = Request.Form["password"];
            string username = Request.Form["username"];
            Employee emp = new Employee();
            EmployeeBUS employeeBUS = new EmployeeBUS();
            emp = employeeBUS.GetEmployeeById(Int32.Parse(ID));
            employeeBUS.UpdateEmployeeInfo(emp, name, phone, adress, password);

            return RedirectToAction("Index", "User");
        }
        public ActionResult Delete(int id)
        {
            EmployeeBUS employeeBUS = new EmployeeBUS();
            employeeBUS.DeleteEmployee(id);
            return RedirectToAction("Index", "User");
        }

        public ActionResult AddUserIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            string username = Request.Form["username"];
            string fullname = Request.Form["fullname"];
            string phone = Request.Form["phone"];
            string adress = Request.Form["address"];
            string password = Request.Form["password"];
            string role = Request.Form["role"];
            Employee emp = new Employee(fullname, adress, phone, username, password, role);
            EmployeeBUS employeeBUS = new EmployeeBUS();
            employeeBUS.AddEmployee(emp);
            return RedirectToAction("Index", "User");
        }
    }
}