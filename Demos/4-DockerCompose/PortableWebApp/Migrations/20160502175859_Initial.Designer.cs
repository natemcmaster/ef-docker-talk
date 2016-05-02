using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PortableWebApp;

namespace PortableWebApp.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20160502175859_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20745");

            modelBuilder.Entity("PortableWebApp.Customer", b =>
                {
                    b.Property<string>("CustomerID");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Country");

                    b.Property<string>("Fax");

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });
        }
    }
}
