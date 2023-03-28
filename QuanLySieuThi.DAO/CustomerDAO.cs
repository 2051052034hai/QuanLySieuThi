using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    public class CustomerDAO
    {
        private QuanLySieuThiContext context;

        public CustomerDAO()
        {
            this.context = new QuanLySieuThiContext();
        }

        public void Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        // Read a customer by ID
        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
        }

        // Update an existing customer
        public void Update(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int customerId)
        {
            Customer customer = GetCustomerById(customerId);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
