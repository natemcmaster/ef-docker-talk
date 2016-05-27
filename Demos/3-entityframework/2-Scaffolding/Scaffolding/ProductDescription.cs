using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("ProductDescription", Schema = "SalesLT")]
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            ProductModelProductDescription = new HashSet<ProductModelProductDescription>();
        }

        public int ProductDescriptionID { get; set; }
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductDescription")]
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescription { get; set; }
    }
}
