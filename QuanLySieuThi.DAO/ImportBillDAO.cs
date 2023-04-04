using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    using QuanLySieuThi.DTO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ImportBillDAO
    {
        private readonly QuanLySieuThiContext context;

        public ImportBillDAO()
        {
            context = new QuanLySieuThiContext();
        }

        public ImportBill GetImportBill(int id)
        {
            return context.ImportBills
                .Include(x => x.Supplier)
                .Include(x => x.ImportBillDetails)
                .SingleOrDefault(x => x.ImportBillID == id);
        }

        public List<ImportBill> GetByMonth(int year, int month)
        {
            return context.ImportBills
                .Include(x => x.Supplier)
                .Include(x => x.ImportBillDetails)
                .Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Year == year && x.CreatedDate.Value.Month == month)
                .ToList();
        }

        public List<ImportBill> GetByYear(int year)
        {
            return context.ImportBills
                .Include(x => x.Supplier)
                .Include(x => x.ImportBillDetails)
                .Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Year == year)
                .ToList();
        }

        public void Save(ImportBill importBill, List<ImportBillDetail> details)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Save import bill and details
                    context.ImportBills.Add(importBill)
                    context.ImportBillDetails.AddRange(details);

                    // Update product unit in stock and import bill subtotal
                    foreach (var detail in details)
                    {
                        var product = context.Products.FirstOrDefault(p => p.ProductID == detail.ProductID);
                        if (product != null)
                        {
                            product.UnitInStock += detail.Quantity ?? 0;
                            context.Entry(product).State = EntityState.Modified;
                        }
                        importBill.SubTotal += detail.Price * detail.Quantity;
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

    }

}
