using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Authenticate(string username, string password)
        {
            return db.Employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
        }

        public int UpdateEmployee(Employee employee)
        {
            try
            {
                var existingEmployee = db.Employees.Find(employee.EmployeeID);

                if (existingEmployee != null)
                {
                    // Update existing employee entity properties
                    existingEmployee.EmployeeName = employee.EmployeeName;
                    existingEmployee.EmployeeAddress = employee.EmployeeAddress;
                    existingEmployee.Phone = employee.Phone;
                    existingEmployee.UserName = employee.UserName;
                    existingEmployee.Password = employee.Password;
                    existingEmployee.Role = employee.Role;

                    // Save changes to the database
                    return db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                return db.SaveChanges();
            }
            catch { return 0; }
        }

        public int DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);

            if (employee != null)
            {
                db.Employees.Remove(employee);
                return db.SaveChanges();
            }
            return 0;
        }

        public bool IsAuthorized(int id, string role)
        {
            var employee = db.Employees.Find(id);
            return employee.Role == role;
        }
    }

}
