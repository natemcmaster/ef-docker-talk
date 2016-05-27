using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("ProductModelProductDescription", Schema = "SalesLT")]
    public partial class ProductModelProductDescription
    {
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string Culture { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductDescriptionID")]
        [InverseProperty("ProductModelProductDescription")]
        public virtual ProductDescription ProductDescription { get; set; }
        [ForeignKey("ProductModelID")]
        [InverseProperty("ProductModelProductDescription")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
