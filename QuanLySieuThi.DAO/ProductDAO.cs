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

        public List<Product> GetProducts(Dictionary<string, string> queryParams)
        {
            var products = context.Products.AsQueryable();

            if (queryParams.ContainsKey("kw"))
            {
                string keyword = queryParams["kw"];
                products = products.Where(p => p.ProductName.Contains(keyword));
            }
            if (queryParams.ContainsKey("categoryId") && queryParams["categoryId"] != null)
            {
                int categoryId = int.Parse(queryParams["categoryId"]);
                products = products.Where(p => p.CateID == (int) categoryId);
            }

            return products.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }
        public Product AddProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
