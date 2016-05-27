using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("Product", Schema = "SalesLT")]
    public partial class Product
    {
        public Product()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string ProductNumber { get; set; }
        [MaxLength(15)]
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        [MaxLength(5)]
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        public int? ProductCategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        [MaxLength(50)]
        public string ThumbnailPhotoFileName { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        [ForeignKey("ProductCategoryID")]
        [InverseProperty("Product")]
        public virtual ProductCategory ProductCategory { get; set; }
        [ForeignKey("ProductModelID")]
        [InverseProperty("Product")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
