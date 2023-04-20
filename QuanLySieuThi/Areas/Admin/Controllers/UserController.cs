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
            string fullname = Request.Form["fullname"];
            string phone = Request.Form["phone"];
            string adress = Request.Form["address"];
            string password = Request.Form["password"];
            string username = Request.Form["username"];
            Employee emp = new Employee();
            //EmployeeDAO dao = new EmployeeDAO();
            //emp = dao.GetEmployeeById(Int32.Parse(ID));
            //dao.UpdateInfo(emp, fullname, phone, adress, password);

            return RedirectToAction("UsersIndex", "UsersList");
        }
        public ActionResult Delete(int id)
        {
            //EmployeeDAO dao = new EmployeeDAO();
            //dao.DeleteEmployee(id);
            return RedirectToAction("UsersIndex", "UsersList");
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
            //Employee emp = new Employee(fullname, adress, phone, username, password, role);
            //EmployeeDAO dao = new EmployeeDAO();
            //dao.Create(emp);
            return RedirectToAction("UsersIndex", "UsersList");
        }
    }
}