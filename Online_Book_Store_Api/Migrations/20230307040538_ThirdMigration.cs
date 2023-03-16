using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Book_Store_Api.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookCategory_BookCategoryCategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_OrderDetail_OrderDetailOrderId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "BookCategory",
                newName: "BookCategories");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_BookCategoryCategoryId",
                table: "Books",
                newName: "IX_Books_BookCategoryCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "ISBN");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: true),
                    BooksISBN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Books_BooksISBN",
                        column: x => x.BooksISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Registrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BooksISBN",
                table: "OrderDetails",
                column: "BooksISBN");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_RegistrationId",
                table: "OrderDetails",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCategories_BookCategoryCategoryId",
                table: "Books",
                column: "BookCategoryCategoryId",
                principalTable: "BookCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_OrderDetails_OrderDetailOrderId",
                table: "Payment",
                column: "OrderDetailOrderId",
                principalTable: "OrderDetails",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCategories_BookCategoryCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_OrderDetails_OrderDetailOrderId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategories",
                table: "BookCategories");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "BookCategories",
                newName: "BookCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookCategoryCategoryId",
                table: "Book",
                newName: "IX_Book_BookCategoryCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "ISBN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooksISBN = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Book_BooksISBN",
                        column: x => x.BooksISBN,
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Registrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BooksISBN",
                table: "OrderDetail",
                column: "BooksISBN");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_RegistrationId",
                table: "OrderDetail",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookCategory_BookCategoryCategoryId",
                table: "Book",
                column: "BookCategoryCategoryId",
                principalTable: "BookCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_OrderDetail_OrderDetailOrderId",
                table: "Payment",
                column: "OrderDetailOrderId",
                principalTable: "OrderDetail",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
