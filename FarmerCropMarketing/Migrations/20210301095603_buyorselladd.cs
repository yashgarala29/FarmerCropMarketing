using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmerCropMarketing.Migrations
{
    public partial class buyorselladd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "buyOrsell",
                table: "Crops",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "itComplited",
                table: "Crops",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buyOrsell",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "itComplited",
                table: "Crops");
        }
    }
}
