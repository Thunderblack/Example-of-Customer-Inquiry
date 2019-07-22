using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Example.WebApi.DataAccess.Migrations
{
    public partial class InitialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(maxLength: 25, nullable: false),
                    customerName = table.Column<string>(maxLength: 20, nullable: false),
                    mobile = table.Column<string>(maxLength: 10, nullable: false),
                    status = table.Column<string>(maxLength: 1, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStatus",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 1, nullable: false),
                    description = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStatus", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsStatus",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 1, nullable: false),
                    description = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsStatus", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    CustomerRefID = table.Column<long>(nullable: false),
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    amount = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    currency = table.Column<string>(maxLength: 3, nullable: false),
                    customerID = table.Column<long>(nullable: false),
                    status = table.Column<string>(maxLength: 1, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerRefID",
                        column: x => x.CustomerRefID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerStatus",
                columns: new[] { "code", "description" },
                values: new object[,]
                {
                    { "A", "Active" },
                    { "L", "Locked" },
                    { "S", "Suspend" },
                    { "C", "Cancel" },
                    { "D", "De-Active" }
                });

            migrationBuilder.InsertData(
                table: "TransactionsStatus",
                columns: new[] { "code", "description" },
                values: new object[,]
                {
                    { "S", "Success" },
                    { "W", "Waiting" },
                    { "C", "Canceled" },
                    { "F", "Failed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_email",
                table: "Customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerRefID",
                table: "Transactions",
                column: "CustomerRefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerStatus");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionsStatus");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
