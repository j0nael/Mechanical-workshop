using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller_mecanico_v2.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Customers_CustomerId",
                table: "SpareParts");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "SpareParts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Customers_CustomerId",
                table: "SpareParts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Customers_CustomerId",
                table: "SpareParts");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "SpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Customers_CustomerId",
                table: "SpareParts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
