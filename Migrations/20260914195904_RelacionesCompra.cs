using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompumundoApis.Migrations
{
    /// <inheritdoc />
    public partial class RelacionesCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetallesPedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "DetallesPedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "CuentaClientes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.Sql("UPDATE Pedidos SET ClienteId = NULL WHERE ClienteId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Clientes WHERE Clientes.Id = Pedidos.ClienteId)");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_PedidoId",
                table: "DetallesPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaClientes_ClienteId",
                table: "CuentaClientes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaClientes_Clientes_ClienteId",
                table: "CuentaClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedidos_Pedidos_PedidoId",
                table: "DetallesPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaClientes_Clientes_ClienteId",
                table: "CuentaClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedidos_Pedidos_PedidoId",
                table: "DetallesPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedidos_PedidoId",
                table: "DetallesPedidos");

            migrationBuilder.DropIndex(
                name: "IX_CuentaClientes_ClienteId",
                table: "CuentaClientes");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetallesPedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "DetallesPedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "CuentaClientes");
        }
    }
}
