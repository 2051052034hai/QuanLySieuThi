using QuanLySieuThi.DAO;
using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.BUS
{
    public class EmployeeBUS
    {
        private readonly EmployeeDAO employeeDAO;

        public EmployeeBUS()
        {
            employeeDAO = new EmployeeDAO();
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeDAO.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return employeeDAO.GetEmployeeById(id);
        }

        public bool AddEmployee(Employee employee)
        {
            if (employee != null && !string.IsNullOrEmpty(employee.EmployeeName) && !string.IsNullOrEmpty(employee.UserName) && !string.IsNullOrEmpty(employee.Password))
            {
                employee.Password = EncryptPassword(employee.Password);
                return employeeDAO.AddEmployee(employee) > 0;
            }
            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (employee != null && employee.EmployeeID > 0 && !string.IsNullOrEmpty(employee.EmployeeName) && !string.IsNullOrEmpty(employee.UserName) && !string.IsNullOrEmpty(employee.Password))
            {
                employee.Password = EncryptPassword(employee.Password);
                return employeeDAO.UpdateEmployee(employee) > 0;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            return employeeDAO.DeleteEmployee(id) > 0;
        }

        private string EncryptPassword(string password)
        {
            // Implement your own password encryption logic here
            return password;
        }

        public Employee Authenticate(string username, string password)
        {
            Employee employee = employeeDAO.GetByUsername(username);
            if (employee == null || !employee.Password.Equals(password))
            {
                return null;
            }
            return employee;
        }
    }

}
