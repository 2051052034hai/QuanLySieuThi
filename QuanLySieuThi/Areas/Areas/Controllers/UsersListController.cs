using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.BUS;
using QuanLySieuThi.DAO;
using QuanLySieuThi.DTO;

namespace QuanLySieuThi.Areas.Areas.Controllers
{
    public class UsersListController : Controller
    {
        // GET: Areas/UsersList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UsersIndex()
        {
            EmployeeDAO empDAO = new EmployeeDAO();

            ViewBag.Employees=empDAO.GetEmployees();
            return View();
        }
        public ActionResult EditUsersIndex(int id)
        {
            EmployeeDAO empDAO = new EmployeeDAO();
            Employee emp = empDAO.ViewDetail(id);
            ViewBag.Username = emp.UserName;
            ViewBag.FullName = emp.EmployeeName;
            ViewBag.Phone = emp.Phone;
            ViewBag.Address = emp.EmployeeAddress;
            ViewBag.Password = emp.Password;
            ViewBag.ID = emp.EmployeeID;

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
            EmployeeDAO dao = new EmployeeDAO();
            emp = dao.GetEmployeeById(Int32.Parse(ID));
            dao.UpdateInfo(emp, fullname, phone, adress, password);

            return RedirectToAction("UsersIndex", "UsersList");
        }
        public ActionResult Delete(int id)
        {
            EmployeeDAO dao = new EmployeeDAO();
            Employee emp = new Employee();
            dao.DeleteEmployee(id);
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
            Employee emp = new Employee(fullname, adress, phone, username, password, role);
            EmployeeDAO dao = new EmployeeDAO();
            dao.Create(emp);
            return RedirectToAction("UsersIndex", "UsersList");
        }
    }
}