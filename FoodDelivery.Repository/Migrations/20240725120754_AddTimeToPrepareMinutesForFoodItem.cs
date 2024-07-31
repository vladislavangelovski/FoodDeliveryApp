using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeToPrepareMinutesForFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeToPrepareMinutes",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToPrepareMinutes",
                table: "FoodItems");
        }
    }
}
