using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmerCropMarketing.Migrations
{
    public partial class addMSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buissnessmen");

            migrationBuilder.AddColumn<int>(
                name: "Crops_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Farmers_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "delivery_date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "order_date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "order_status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "seller_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_pricer",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Farmers_address",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_email",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_image",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Farmers_mobile_no",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Farmers_name",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Crops_description",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Crops_image",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Crops_name",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Crops_price",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Crops_quantity",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Farmers_id",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seller_id",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Crops_id",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Farmers_id",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MSPCropsDetails",
                columns: table => new
                {
                    MSPCrops_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crops_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crops_price = table.Column<int>(type: "int", nullable: false),
                    Crops_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crops_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crop_Buying_Staring_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crop_Buying_End_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSPCropsDetails", x => x.MSPCrops_id);
                });

            migrationBuilder.CreateTable(
                name: "MSPSellCrops",
                columns: table => new
                {
                    MSPSell_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmers_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Farmers_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Farmers_mobile_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Farmers_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MSPCrops_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSPSellCrops", x => x.MSPSell_id);
                    table.ForeignKey(
                        name: "FK_MSPSellCrops_MSPCropsDetails_MSPCrops_id",
                        column: x => x.MSPCrops_id,
                        principalTable: "MSPCropsDetails",
                        principalColumn: "MSPCrops_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Crops_id",
                table: "Orders",
                column: "Crops_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Farmers_id",
                table: "Orders",
                column: "Farmers_id");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_Seller_id",
                table: "Crops",
                column: "Seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Crops_id",
                table: "Cart",
                column: "Crops_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Farmers_id",
                table: "Cart",
                column: "Farmers_id");

            migrationBuilder.CreateIndex(
                name: "IX_MSPSellCrops_MSPCrops_id",
                table: "MSPSellCrops",
                column: "MSPCrops_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Crops_Crops_id",
                table: "Cart",
                column: "Crops_id",
                principalTable: "Crops",
                principalColumn: "Crops_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Farmers_Farmers_id",
                table: "Cart",
                column: "Farmers_id",
                principalTable: "Farmers",
                principalColumn: "Farmers_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Farmers_Seller_id",
                table: "Crops",
                column: "Seller_id",
                principalTable: "Farmers",
                principalColumn: "Farmers_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Crops_Crops_id",
                table: "Orders",
                column: "Crops_id",
                principalTable: "Crops",
                principalColumn: "Crops_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Farmers_Farmers_id",
                table: "Orders",
                column: "Farmers_id",
                principalTable: "Farmers",
                principalColumn: "Farmers_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Crops_Crops_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Farmers_Farmers_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Farmers_Seller_id",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Crops_Crops_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Farmers_Farmers_id",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "MSPSellCrops");

            migrationBuilder.DropTable(
                name: "MSPCropsDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Crops_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Farmers_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Crops_Seller_id",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Crops_id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Farmers_id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Crops_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Farmers_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "delivery_date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "order_date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "order_status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "seller_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "total_pricer",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Farmers_address",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Farmers_email",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Farmers_image",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Farmers_mobile_no",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Farmers_name",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Crops_description",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Crops_image",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Crops_name",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Crops_price",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Crops_quantity",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Farmers_id",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Seller_id",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Crops_id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Farmers_id",
                table: "Cart");

            migrationBuilder.CreateTable(
                name: "Buissnessmen",
                columns: table => new
                {
                    Buissnessman_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buissnessmen", x => x.Buissnessman_id);
                });
        }
    }
}
