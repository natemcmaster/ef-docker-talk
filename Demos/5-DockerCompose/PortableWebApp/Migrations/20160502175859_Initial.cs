using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortableWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactTitle = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
