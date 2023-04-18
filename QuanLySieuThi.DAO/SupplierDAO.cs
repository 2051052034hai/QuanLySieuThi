using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    public class SupplierDAO
    {
        // Fields
        private QuanLySieuThiContext context;

        // Constructor
        public SupplierDAO()
        {
            this.context = new QuanLySieuThiContext();
        }

        // Create a new supplier
        public int Create(Supplier supplier)
        {
            try
            {
                context.Suppliers.Add(supplier);
                return context.SaveChanges();
            }
            catch { return 0; }
        }

        // Read a supplier by ID
        public Supplier GetSupplierById(int supplierId)
        {
            return context.Suppliers.Find(supplierId);
        }

        // Read a supplier by name
        public Supplier GetSupplierByName(string supplierName)
        {
            return context.Suppliers.FirstOrDefault(s => s.SupplierName == supplierName);
        }

        // Update an existing supplier
        public int Update(Supplier supplier)
        {
            context.Entry(supplier).State = EntityState.Modified;
            return context.SaveChanges();
        }

        // Delete an existing supplier by ID and return the number of rows affected
        public int Delete(int supplierId)
        {
            Supplier supplier = GetSupplierById(supplierId);
            context.Suppliers.Remove(supplier);
            return context.SaveChanges();
        }
    }
}
