using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeliveryOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "RestaurantFoodItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrder_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodItemInDelivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemInRestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemInDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItemInDelivery_DeliveryOrder_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "DeliveryOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodItemInDelivery_RestaurantFoodItems_FoodItemInRestaurantId",
                        column: x => x.FoodItemInRestaurantId,
                        principalTable: "RestaurantFoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodItems_CustomerId",
                table: "RestaurantFoodItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrder_OwnerId",
                table: "DeliveryOrder",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemInDelivery_DeliveryOrderId",
                table: "FoodItemInDelivery",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemInDelivery_FoodItemInRestaurantId",
                table: "FoodItemInDelivery",
                column: "FoodItemInRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoodItems_AspNetUsers_CustomerId",
                table: "RestaurantFoodItems",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoodItems_AspNetUsers_CustomerId",
                table: "RestaurantFoodItems");

            migrationBuilder.DropTable(
                name: "FoodItemInDelivery");

            migrationBuilder.DropTable(
                name: "DeliveryOrder");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantFoodItems_CustomerId",
                table: "RestaurantFoodItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "RestaurantFoodItems");
        }
    }
}
