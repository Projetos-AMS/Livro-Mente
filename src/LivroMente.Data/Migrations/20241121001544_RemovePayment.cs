using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivroMente.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id");
        }
    }
}
