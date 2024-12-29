using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPCleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFavoriteMovies_Customers_CustomerId",
                table: "CustomerFavoriteMovies");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerFavoriteMovies",
                newName: "CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFavoriteMovies_Customers_CustomersId",
                table: "CustomerFavoriteMovies",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFavoriteMovies_Customers_CustomersId",
                table: "CustomerFavoriteMovies");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerFavoriteMovies",
                newName: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFavoriteMovies_Customers_CustomerId",
                table: "CustomerFavoriteMovies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
