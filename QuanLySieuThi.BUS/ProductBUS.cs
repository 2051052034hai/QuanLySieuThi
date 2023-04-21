using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using System.Data.Entity.Core.Mapping;

namespace QuanLySieuThi.BUS
{
    public class ProductBUS
    {
        private readonly ProductDAO productDAO;
        public ProductBUS()
        {
           productDAO = new ProductDAO();
        }
        public List<Product> GetProducts()
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProducts();
        }
        public Product Add(Product product)
        {
            return productDAO.AddProduct(product);
        }
        public void Delete(int id )
        {
            productDAO.DeleteProduct(id);
        }
        public List<Product> GetProducts(string kw)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProducts(kw);
        }

        public List<Product> GetProducts(Dictionary<string, string> queryParams)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProducts(queryParams);
        }

        public object GetProduct(int? productID)
        {
            throw new NotImplementedException();
        }
        public bool UpdateProductInfo(Product product, string name, string unitPrice, string unitInStock, string cateID, string description, string suppilerID, string image_Url)
        {
            try
            {
                // Call the UpdateInfo() method on the repository instance
                return productDAO.UpdateInfo(product, name, unitPrice, unitInStock, cateID, description, suppilerID, image_Url);
            }
            catch (Exception ex)
            {
                return false;
            }
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
