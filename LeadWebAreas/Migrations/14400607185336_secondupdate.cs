using Microsoft.EntityFrameworkCore.Migrations;

namespace LeadCoreAreas.Migrations
{
    public partial class secondupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Stores",
                newName: "StoreName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stores",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreName",
                table: "Stores",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Stores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Stock",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Products",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
