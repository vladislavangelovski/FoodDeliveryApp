using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurantToFoodItemInDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "FoodItemInDeliveries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemInDeliveries_RestaurantId",
                table: "FoodItemInDeliveries",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemInDeliveries_Restaurants_RestaurantId",
                table: "FoodItemInDeliveries",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemInDeliveries_Restaurants_RestaurantId",
                table: "FoodItemInDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_FoodItemInDeliveries_RestaurantId",
                table: "FoodItemInDeliveries");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "FoodItemInDeliveries");
        }
    }
}
