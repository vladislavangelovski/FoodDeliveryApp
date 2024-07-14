using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrder_AspNetUsers_OwnerId",
                table: "DeliveryOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDelivery_DeliveryOrder_DeliveryOrderId",
                table: "FoodItemInDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDelivery_RestaurantFoodItems_FoodItemInRestaurantId",
                table: "FoodItemInDelivery");

            migrationBuilder.DropTable(
                name: "RestaurantFoodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemInDelivery",
                table: "FoodItemInDelivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryOrder",
                table: "DeliveryOrder");

            migrationBuilder.RenameTable(
                name: "FoodItemInDelivery",
                newName: "FoodItemInDeliveries");

            migrationBuilder.RenameTable(
                name: "DeliveryOrder",
                newName: "DeliveryOrders");

            migrationBuilder.RenameColumn(
                name: "FoodItemInRestaurantId",
                table: "FoodItemInDeliveries",
                newName: "FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemInDelivery_FoodItemInRestaurantId",
                table: "FoodItemInDeliveries",
                newName: "IX_FoodItemInDeliveries_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemInDelivery_DeliveryOrderId",
                table: "FoodItemInDeliveries",
                newName: "IX_FoodItemInDeliveries_DeliveryOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryOrder_OwnerId",
                table: "DeliveryOrders",
                newName: "IX_DeliveryOrders_OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "FoodItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "FoodItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemInDeliveries",
                table: "FoodItemInDeliveries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryOrders",
                table: "DeliveryOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CustomerId",
                table: "FoodItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_RestaurantId",
                table: "FoodItems",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrders_AspNetUsers_OwnerId",
                table: "DeliveryOrders",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDeliveries_DeliveryOrders_DeliveryOrderId",
                table: "FoodItemInDeliveries",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDeliveries_FoodItems_FoodItemId",
                table: "FoodItemInDeliveries",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_AspNetUsers_CustomerId",
                table: "FoodItems",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Restaurants_RestaurantId",
                table: "FoodItems",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrders_AspNetUsers_OwnerId",
                table: "DeliveryOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDeliveries_DeliveryOrders_DeliveryOrderId",
                table: "FoodItemInDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDeliveries_FoodItems_FoodItemId",
                table: "FoodItemInDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_AspNetUsers_CustomerId",
                table: "FoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Restaurants_RestaurantId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_CustomerId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_RestaurantId",
                table: "FoodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemInDeliveries",
                table: "FoodItemInDeliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryOrders",
                table: "DeliveryOrders");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "FoodItems");

            migrationBuilder.RenameTable(
                name: "FoodItemInDeliveries",
                newName: "FoodItemInDelivery");

            migrationBuilder.RenameTable(
                name: "DeliveryOrders",
                newName: "DeliveryOrder");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "FoodItemInDelivery",
                newName: "FoodItemInRestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemInDeliveries_FoodItemId",
                table: "FoodItemInDelivery",
                newName: "IX_FoodItemInDelivery_FoodItemInRestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemInDeliveries_DeliveryOrderId",
                table: "FoodItemInDelivery",
                newName: "IX_FoodItemInDelivery_DeliveryOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryOrders_OwnerId",
                table: "DeliveryOrder",
                newName: "IX_DeliveryOrder_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemInDelivery",
                table: "FoodItemInDelivery",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryOrder",
                table: "DeliveryOrder",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RestaurantFoodItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodItems_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodItems_CustomerId",
                table: "RestaurantFoodItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodItems_FoodItemId",
                table: "RestaurantFoodItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodItems_RestaurantId",
                table: "RestaurantFoodItems",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrder_AspNetUsers_OwnerId",
                table: "DeliveryOrder",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDelivery_DeliveryOrder_DeliveryOrderId",
                table: "FoodItemInDelivery",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDelivery_RestaurantFoodItems_FoodItemInRestaurantId",
                table: "FoodItemInDelivery",
                column: "FoodItemInRestaurantId",
                principalTable: "RestaurantFoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
