using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySieuThi.DTO;

namespace QuanLySieuThi.DAO
{
    public class ProductDAO
    {
        private QuanLySieuThiContext context;
        public ProductDAO()
        {
            context = new QuanLySieuThiContext();
        }
        public List<Product> GetProducts()
        {
            List<Product> products = context.Products.ToList();
            return products;
        }

        public List<Product> GetProducts(string keyword)
        {
            List<Product> products = context.Products.Where(p => p.ProductName.Contains(keyword)).ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            return context.Products.SingleOrDefault(p => p.ProductID == id);
        }
        public Product AddProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
