using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scaffolding
{
    public partial class adventureworksContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=adventureworks;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.StateProvince)
                    .HasName("IX_Address_StateProvince");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_Address_rowguid")
                    .IsUnique();

                entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvince, e.PostalCode, e.CountryRegion })
                    .HasName("IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion");

                entity.Property(e => e.CountryRegion).HasColumnType("Name");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.StateProvince).HasColumnType("Name");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<BuildVersion>(entity =>
            {
                entity.HasKey(e => e.SystemInformationID)
                    .HasName("PK__BuildVer__35E58ECACC4CCA70");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.VersionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_Customer_EmailAddress");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_Customer_rowguid")
                    .IsUnique();

                entity.Property(e => e.FirstName).HasColumnType("Name");

                entity.Property(e => e.LastName).HasColumnType("Name");

                entity.Property(e => e.MiddleName).HasColumnType("Name");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.NameStyle)
                    .HasColumnType("NameStyle")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PasswordHash).HasColumnType("varchar(128)");

                entity.Property(e => e.PasswordSalt).HasColumnType("varchar(10)");

                entity.Property(e => e.Phone).HasColumnType("Phone");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerID, e.AddressID })
                    .HasName("PK_CustomerAddress_CustomerID_AddressID");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_CustomerAddress_rowguid")
                    .IsUnique();

                entity.Property(e => e.AddressType).HasColumnType("Name");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.ErrorTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UserName).HasColumnType("sysname");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name).HasColumnType("Name");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.Property(e => e.Weight).HasColumnType("decimal");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name).HasColumnType("Name");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_ProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasIndex(e => e.CatalogDescription)
                    .HasName("SXI_ProductModel_Description");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductModel_Name")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_ProductModel_rowguid")
                    .IsUnique();

                entity.Property(e => e.CatalogDescription).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name).HasColumnType("Name");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductModelProductDescription>(entity =>
            {
                entity.HasKey(e => new { e.ProductModelID, e.ProductDescriptionID, e.Culture })
                    .HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_ProductModelProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.Culture).HasColumnType("nchar(6)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderID, e.SalesOrderDetailID })
                    .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

                entity.HasIndex(e => e.ProductID)
                    .HasName("IX_SalesOrderDetail_ProductID");

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_SalesOrderDetail_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesOrderDetailID).ValueGeneratedOnAdd();

                entity.Property(e => e.LineTotal)
                    .HasColumnType("numeric")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.UnitPriceDiscount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.0");

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderID)
                    .HasName("PK_SalesOrderHeader_SalesOrderID");

                entity.HasIndex(e => e.CustomerID)
                    .HasName("IX_SalesOrderHeader_CustomerID");

                entity.HasIndex(e => e.SalesOrderNumber)
                    .HasName("AK_SalesOrderHeader_SalesOrderNumber")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid)
                    .HasName("AK_SalesOrderHeader_rowguid")
                    .IsUnique();

                entity.Property(e => e.AccountNumber).HasColumnType("AccountNumber");

                entity.Property(e => e.CreditCardApprovalCode).HasColumnType("varchar(15)");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.OnlineOrderFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PurchaseOrderNumber).HasColumnType("OrderNumber");

                entity.Property(e => e.RevisionNumber).HasDefaultValueSql("0");

                entity.Property(e => e.SalesOrderNumber).ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("1");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TaxAmt)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            });
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BuildVersion> BuildVersion { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}