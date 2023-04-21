using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySieuThi.DTO;
using QuanLySieuThi.BUS;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using QuanLySieuThi.Filter;

namespace QuanLySieuThi.Controllers
{
    [CommonAttributeFilter]
    public class CartController : Controller
    {
        private List<BillDetail> Cart
        {
            get
            {
                var cart = Session["Cart"] as List<BillDetail>;
                if (cart == null)
                {
                    cart = new List<BillDetail>();
                    Session["Cart"] = cart;
                }
                return cart;
            }
            set
            {
                Session["Cart"] = value;
            }
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cart = this.Cart;

            ViewBag.Cart = cart;

            return View();
        }
        /* -------phương thức đếm số lượng sản phẩm trong giỏ--------------*/
        public ActionResult Count()
        {
            var cart = this.Cart;
            var cartCount = cart.Sum(BD => BD.Quantity);

            return Json(new { cartCount }, JsonRequestBehavior.AllowGet);
        }

        /* -------phương thức khi thêm sản phẩm vào trong giỏ--------------*/
        [HttpPost]
        public ActionResult AddCart()
        {

            var cart = this.Cart;

            using (var reader = new StreamReader(Request.GetBufferlessInputStream()))
            {
                var body = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<dynamic>(body);

                int productId = data.productId;
                int productQuality = data.productQuality;
                decimal productPrice = data.productPrice;

                var existingBillDetail = cart.FirstOrDefault(BD => BD.ProductID == productId);

                if (existingBillDetail != null)
                {
                    // Nếu sản phẩm đã tồn tại, cập nhật trường quality của sản phẩm đó
                    existingBillDetail.Quantity += productQuality;

                }
                else
                {
                    ProductBUS bus = new ProductBUS();
                    Product p = new Product();
                    p = bus.GetProduct(productId);

                    BillDetail newBillDetail = new BillDetail(productQuality, productPrice, productId, p);

                    cart.Add(newBillDetail);
                }

                Session["Cart"] = cart;
            }

            return View();
        }

        /* -------phương thức khi thanh toán sản phẩm trong giỏ--------------*/
        public ActionResult Checkout()
        {
            // Lấy giỏ hàng từ Session
            var cart = this.Cart;
            DateTime DateNow = DateTime.Now;

            // Tính tổng số tiền cần thanh toán
            decimal total = 0;
            foreach (var item in cart)
            {

                total += (decimal)item.Quantity * (decimal)item.Price;

            }
            // Lưu thông tin vào cơ sở dữ liệu
            BillBUS billBUS = new BillBUS();
            Bill bill = new Bill(DateNow, total);
            billBUS.Create(bill, cart);

            // Xóa giỏ hàng khỏi Session
            Session.Remove("Cart");
            return View();
        }

        /* -------phương thức khi xoá sản phẩm trong giỏ------------*/
        public ActionResult DeleteCart(int productId)
        {
            var cart = this.Cart;
            var existingBillDetail = cart.FirstOrDefault(BD => BD.ProductID == productId);

            if (existingBillDetail != null)
            {
                // Nếu sản phẩm đã tồn tại trong giỏ hàng, tiến hành xóa
                cart.Remove(existingBillDetail);
                Session["Cart"] = cart; // Lưu giỏ hàng mới vào session
            }

            return RedirectToAction("Index");
        }
    }
}