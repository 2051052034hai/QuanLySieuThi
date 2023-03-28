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
        public void Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
        }

        // Read a supplier by ID
        public Supplier GetSupplierById(int supplierId)
        {
            return context.Suppliers.FirstOrDefault(s => s.SupplierID == supplierId);
        }

        // Read a supplier by name
        public Supplier GetSupplierByName(string supplierName)
        {
            return context.Suppliers.FirstOrDefault(s => s.SupplierName == supplierName);
        }

        // Update an existing supplier
        public void Update(Supplier supplier)
        {
            context.Entry(supplier).State = EntityState.Modified;
            context.SaveChanges();
        }

        // Delete an existing supplier by ID
        public void Delete(int supplierId)
        {
            Supplier supplier = GetSupplierById(supplierId);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
        }
    }
}
