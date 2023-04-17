using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Project.Migrations
{
    /// <inheritdoc />
    public partial class addBuyerIdOnOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Orders");
        }
    }
}
