using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName" },
                values: new object[] { 1, "Cairo, Nasr City", "Customer1" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName" },
                values: new object[] { 2, "Cairo, Maadi", "Customer2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName" },
                values: new object[] { 3, "Cairo, 5th Settlement", "Customer3" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "CustomerId", "RegisterNumber", "ShowStatus" },
                values: new object[,]
                {
                    { "YS2R4X20005399401", 1, "ABC123", false },
                    { "VLUR4X20009093588", 1, "DEF456", false },
                    { "VLUR4X20009048066", 1, "GHI789", false },
                    { "YS2R4X20005388011", 2, "JKL012", false },
                    { "YS2R4X20005387949", 2, "MNO345", false },
                    { "YS2R4X20005387765", 3, "PQR678", false },
                    { "YS2R4X20005387055", 3, "STU901", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "VLUR4X20009048066");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "VLUR4X20009093588");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "YS2R4X20005387055");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "YS2R4X20005387765");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "YS2R4X20005387949");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "YS2R4X20005388011");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: "YS2R4X20005399401");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);
        }
    }
}
