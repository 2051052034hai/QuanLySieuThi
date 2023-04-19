using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
namespace QuanLySieuThi.DAO
{
    public class EmployeeDAO
    {
        private QuanLySieuThiContext db;

        public EmployeeDAO()
        {
            db = new QuanLySieuThiContext();
        }
        
        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }
        public Employee ViewDetail(int id)
        {
            return db.Employees.Find(id);
        }
        public Employee GetEmployeeById(int id)
        {
            return db.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }
        public bool UpdateInfo(Employee employee, string name, string phone, string address, string password)
        {
            try
            {
                employee.EmployeeName = name;
                employee.Phone = phone;
                employee.EmployeeAddress = address;
                employee.Password = password;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
        public void Create(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the validation errors
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the error messages together
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Throw a new exception with the full error message
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
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
