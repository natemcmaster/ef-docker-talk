using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("ProductCategory", Schema = "SalesLT")]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }

        public int ProductCategoryID { get; set; }
        public int? ParentProductCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductCategory")]
        public virtual ICollection<Product> Product { get; set; }
        [ForeignKey("ParentProductCategoryID")]
        [InverseProperty("InverseParentProductCategory")]
        public virtual ProductCategory ParentProductCategory { get; set; }
        [InverseProperty("ParentProductCategory")]
        public virtual ICollection<ProductCategory> InverseParentProductCategory { get; set; }
    }
}
