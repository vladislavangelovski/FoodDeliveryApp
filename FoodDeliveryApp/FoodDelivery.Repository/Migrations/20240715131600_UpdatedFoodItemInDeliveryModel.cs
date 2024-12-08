using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFoodItemInDeliveryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDeliveries_DeliveryOrders_DeliveryOrderId",
                table: "FoodItemInDeliveries");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "FoodItemInDeliveries");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryOrderId",
                table: "FoodItemInDeliveries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDeliveries_DeliveryOrders_DeliveryOrderId",
                table: "FoodItemInDeliveries",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDeliveries_DeliveryOrders_DeliveryOrderId",
                table: "FoodItemInDeliveries");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryOrderId",
                table: "FoodItemInDeliveries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "FoodItemInDeliveries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDeliveries_DeliveryOrders_DeliveryOrderId",
                table: "FoodItemInDeliveries",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");
        }
    }
}
