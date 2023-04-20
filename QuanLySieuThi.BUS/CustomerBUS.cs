using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;

namespace QuanLySieuThi.BUS
{
    public class CustomerBUS
    {
        private CustomerDAO customerDAO;
        public CustomerBUS()
        {
            customerDAO = new CustomerDAO();
        }

        public Customer GetCustomerById(int id)
        {
            return customerDAO.GetCustomerById(id);
        }

        public List<Customer> GetCustomers()
        {
            return null;
        }

        public int Create(Customer customer)
        {
            if (customerDAO.GetByUsername(customer.UserName) != null)
                return 0;
            return customerDAO.Create(customer);
        }
        public int Update(String ID, String fullname, String phone, String address, String password, int point)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer = customerDAO.GetCustomerById(int.Parse(ID));
            customer.CustomerName = fullname;
            customer.CustomerPhone = phone;
            customer.CustomerAddress = address; 
            customer.Password = password;
            customer.AccumulatePoint = point;
            if (customerDAO.Update(customer) > 0)
                return 1;
            return 0;
        }
        public int Update(string ID, string password, string newPass)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer = customerDAO.GetCustomerById(int.Parse(ID));
            if (!customer.Password.Equals(password)) {
                return 0;
            }
            customer.Password = newPass;
            if (customerDAO.Update(customer) > 0)
                return 1;
            return 0;
        }
        public Customer Authenticate(string username, string password)
        {
            Customer customer = customerDAO.GetByUsername(username);
            if (customer == null || !customer.Password.Equals(password))
                return null;
            return customer;
        }
    }
}
