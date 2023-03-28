using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    public class BillDAO
    {
        private readonly QuanLySieuThiContext context;

        public BillDAO()
        {
            context = new QuanLySieuThiContext();
        }

        public Bill Create(Bill bill, List<BillDetail> billDetails)
        {
            // Add bill to database
            context.Bills.Add(bill);
            context.SaveChanges();

            // Assign BillID to each BillDetail
            foreach (var billDetail in billDetails)
            {
                billDetail.BillID = bill.BillID;
            }

            // Add bill details to database
            context.BillDetails.AddRange(billDetails);
            context.SaveChanges();

            return bill;
        }

        public Bill GetBillById(int id)
        {
            return context.Bills.FirstOrDefault(b => b.BillID == id);
        }

        public List<Bill> GetAll()
        {
            return context.Bills.ToList();
        }

        public List<Bill> GetBillsByCustomerId(int customerId)
        {
            return context.Bills.Where(b => b.CustomerID == customerId).ToList();
        }

        public void Update(Bill bill)
        {
            context.Entry(bill).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Bill bill)
        {
            context.Bills.Remove(bill);
            context.SaveChanges();
        }
    }

}
