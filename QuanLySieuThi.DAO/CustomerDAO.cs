using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            try
            {
                context.Customers.Add(customer);
                context.SaveChanges();
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

        // Read a customer by ID
        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
        }
        public Customer ViewDetail(int id)
        {
            return context.Customers.Find(id);
        }
        // Update an existing customer
        public void Update(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
        }
        
        public bool UpdateInfo(Customer customer, string name, string phone , string address, string password)
        {
            try
            {
                customer.CustomerName = name;
                customer.CustomerPhone = phone;
                customer.CustomerAddress = address;
                customer.Password = password;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public void Delete(int customerId)
        {
            Customer customer = GetCustomerById(customerId);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
