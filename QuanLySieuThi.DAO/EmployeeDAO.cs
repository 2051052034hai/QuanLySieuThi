using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    public class EmployeeDAO
    {
        private QuanLySieuThiContext db;

        public EmployeeDAO()
        {
            db = new QuanLySieuThiContext();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public Employee Authenticate(string username, string password)
        {
            return db.Employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public bool IsAuthorized(int id, string role)
        {
            var employee = db.Employees.Find(id);
            return employee.Role == role;
        }
    }

}
