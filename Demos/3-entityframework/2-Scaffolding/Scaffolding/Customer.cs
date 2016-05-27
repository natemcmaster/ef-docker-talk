using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    [Table("Customer", Schema = "SalesLT")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public int CustomerID { get; set; }
        public bool NameStyle { get; set; }
        [MaxLength(8)]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Suffix { get; set; }
        [MaxLength(128)]
        public string CompanyName { get; set; }
        [MaxLength(256)]
        public string SalesPerson { get; set; }
        [MaxLength(50)]
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
