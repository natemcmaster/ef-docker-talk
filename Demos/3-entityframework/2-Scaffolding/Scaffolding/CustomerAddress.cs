using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("CustomerAddress", Schema = "SalesLT")]
    public partial class CustomerAddress
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        [Required]
        public string AddressType { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("AddressID")]
        [InverseProperty("CustomerAddress")]
        public virtual Address Address { get; set; }
        [ForeignKey("CustomerID")]
        [InverseProperty("CustomerAddress")]
        public virtual Customer Customer { get; set; }
    }
}
