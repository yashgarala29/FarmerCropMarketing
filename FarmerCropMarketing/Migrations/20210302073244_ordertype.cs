using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmerCropMarketing.Migrations
{
    public partial class ordertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ordertype",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ordertype",
                table: "Orders");
        }
    }
}
