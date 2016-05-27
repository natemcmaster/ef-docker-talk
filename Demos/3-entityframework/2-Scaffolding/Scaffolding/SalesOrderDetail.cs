using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("SalesOrderDetail", Schema = "SalesLT")]
    public partial class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductID")]
        [InverseProperty("SalesOrderDetail")]
        public virtual Product Product { get; set; }
        [ForeignKey("SalesOrderID")]
        [InverseProperty("SalesOrderDetail")]
        public virtual SalesOrderHeader SalesOrder { get; set; }
    }
}
