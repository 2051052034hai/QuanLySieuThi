namespace QuanLySieuThi.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            EventDetails = new HashSet<EventDetail>();
            ImportBillDetails = new HashSet<ImportBillDetail>();
        }

        public Product(string productName, string unitPrice, string unitInStock, string cateID, string suppilerID, string description, string image_Url)
        {
            ProductName = productName;
            UnitPrice = decimal.Parse(unitPrice);
            UnitInStock = int.Parse(unitInStock);
            CateID = int.Parse(cateID);
            SuppilerID = suppilerID;
            Description = description;
            Image_Url = image_Url;
        }

        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public int CateID { get; set; }

        [Required]
        [StringLength(50)]
        public string SuppilerID { get; set; }

        public string Description { get; set; }

        [StringLength(200)]
        public string Image_Url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventDetail> EventDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }
    }
}
