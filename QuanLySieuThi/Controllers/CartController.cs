using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.DAO;
using QuanLySieuThi.BUS;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using QuanLySieuThi.Filter;

namespace QuanLySieuThi.Controllers
{
    [AddCategoriesFilter]
    public class CartController : Controller
    {
        // GET: Cart
        [HttpPost]
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<Product> ?? new List<Product>();
            Session["Cart"] = cart;

            using (var reader = new StreamReader(Request.GetBufferlessInputStream()))
            {
                var body = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<dynamic>(body);

                int productId = data.productId;
                int productQuality = data.productQuality;

                var existingProduct = cart.FirstOrDefault(p => p.ProductID == productId);

                //if (existingProduct != null)
                //{
                //    // Nếu sản phẩm đã tồn tại, cập nhật trường quality của sản phẩm đó
                //    existingProduct.ProductQuality += productQuality;
                //}

                ProductBUS bus = new ProductBUS();
                Product newProduct = new Product();
                newProduct = bus.GetProduct(productId);

            }
            
            return View();
        }
    }
}