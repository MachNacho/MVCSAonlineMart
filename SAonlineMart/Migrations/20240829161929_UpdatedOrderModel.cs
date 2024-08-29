using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAonlineMart.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_order_OrderID",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "orderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderID",
                table: "orderItems",
                newName: "IX_orderItems_OrderID");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cardNumber",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cvv",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "expdate",
                table: "order",
                type: "date",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_order_OrderID",
                table: "orderItems",
                column: "OrderID",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_order_OrderID",
                table: "orderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "address",
                table: "order");

            migrationBuilder.DropColumn(
                name: "cardNumber",
                table: "order");

            migrationBuilder.DropColumn(
                name: "cvv",
                table: "order");

            migrationBuilder.DropColumn(
                name: "expdate",
                table: "order");

            migrationBuilder.RenameTable(
                name: "orderItems",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_OrderID",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_order_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
