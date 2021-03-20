using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmerCropMarketing.Migrations
{
    public partial class mspsellchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Farmers_address",
                table: "MSPSellCrops");

            migrationBuilder.DropColumn(
                name: "Farmers_email",
                table: "MSPSellCrops");

            migrationBuilder.DropColumn(
                name: "Farmers_mobile_no",
                table: "MSPSellCrops");

            migrationBuilder.DropColumn(
                name: "Farmers_name",
                table: "MSPSellCrops");

            migrationBuilder.AddColumn<int>(
                name: "Crops_quantity",
                table: "MSPSellCrops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Farmers_id",
                table: "MSPSellCrops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seller_id",
                table: "MSPSellCrops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MSPSellCrops_Seller_id",
                table: "MSPSellCrops",
                column: "Seller_id");

            migrationBuilder.AddForeignKey(
                name: "FK_MSPSellCrops_Farmers_Seller_id",
                table: "MSPSellCrops",
                column: "Seller_id",
                principalTable: "Farmers",
                principalColumn: "Farmers_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MSPSellCrops_Farmers_Seller_id",
                table: "MSPSellCrops");

            migrationBuilder.DropIndex(
                name: "IX_MSPSellCrops_Seller_id",
                table: "MSPSellCrops");

            migrationBuilder.DropColumn(
                name: "Crops_quantity",
                table: "MSPSellCrops");

            migrationBuilder.DropColumn(
                name: "Farmers_id",
                table: "MSPSellCrops");

            migrationBuilder.DropColumn(
                name: "Seller_id",
                table: "MSPSellCrops");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_address",
                table: "MSPSellCrops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_email",
                table: "MSPSellCrops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_mobile_no",
                table: "MSPSellCrops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_name",
                table: "MSPSellCrops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
