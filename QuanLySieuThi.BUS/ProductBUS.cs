using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;

namespace QuanLySieuThi.BUS
{
    public class ProductBUS
    {
        public List<Product> GetProducts()
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProducts();
        }

        public Product GetProduct(int id)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductById(id);
        }

        public Product GetProduct(string id)
        {
            return GetProduct(Convert.ToInt32(id));
        }
    }
}
