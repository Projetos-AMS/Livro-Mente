using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivroMente.Data.Migrations
{
    /// <inheritdoc />
    public partial class Drop_Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdressId",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
