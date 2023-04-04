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
    }
}
