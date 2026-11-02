using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompumundoApis.Migrations;

[Migration("20260930000000_ImagenProducto")]
public partial class ImagenProducto : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ImagenUrl",
            table: "Productos",
            type: "nvarchar(max)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "ImagenUrl", table: "Productos");
    }
}
