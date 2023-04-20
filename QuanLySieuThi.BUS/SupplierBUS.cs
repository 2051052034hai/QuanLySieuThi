using QuanLySieuThi.DAO;
using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.BUS
{
    public class SupplierBUS
    {
        private readonly SupplierDAO supplierDAO;

        public SupplierBUS()
        {
            supplierDAO = new SupplierDAO();
        }

        public int Create(Supplier supplier)
        {
            try
            {
                return supplierDAO.Create(supplier);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return supplierDAO.GetSupplierById(supplierId);
        }

        public Supplier GetSupplierByName(string supplierName)
        {
            return supplierDAO.GetSupplierByName(supplierName);
        }

        public int Update(Supplier supplier)
        {
            int result = 0;

            try
            {
                supplierDAO.Update(supplier);
                result = 1;
            }
            catch (Exception)
            {
                // Log the exception
            }

            return result;
        }

        public int Delete(int supplierId)
        {
            try
            {
                return supplierDAO.Delete(supplierId);
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}
