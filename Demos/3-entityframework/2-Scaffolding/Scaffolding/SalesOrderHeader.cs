using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("SalesOrderHeader", Schema = "SalesLT")]
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        [Required]
        [MaxLength(25)]
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int? ShipToAddressID { get; set; }
        public int? BillToAddressID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShipMethod { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("SalesOrder")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        [ForeignKey("BillToAddressID")]
        [InverseProperty("SalesOrderHeaderBillToAddress")]
        public virtual Address BillToAddress { get; set; }
        [ForeignKey("CustomerID")]
        [InverseProperty("SalesOrderHeader")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("ShipToAddressID")]
        [InverseProperty("SalesOrderHeaderShipToAddress")]
        public virtual Address ShipToAddress { get; set; }
    }
}
