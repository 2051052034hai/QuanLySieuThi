namespace QuanLySieuThi.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {

        public BillDetail(int Quantity, decimal Price, int ProductID, Product product)
        {
            this.Quantity = Quantity;
            this.Price = Price;
            this.ProductID = ProductID;
            this.Product = product;
        }
        public int ID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int ProductID { get; set; }

        public int BillID { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }
    }
}
