using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class CouponTables : Migration
    {
        /// <inheritdoc />
        /// I think maybe coder can add new data or update data in here. Let check it later.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // There is a bug here. When data table is exists maybe it will throw an exception when run app.
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode", "DiscountAmount", "LastUpdated", "MinAmount" },
                values: new object[,]
                {
                    { 1, "03cccfa5-9a07-4348-a5d1-3f761bdf72b9", 10.0, new DateTime(2024, 5, 1, 16, 0, 59, 886, DateTimeKind.Utc).AddTicks(6736), 20000 },
                    { 2, "447610f7-f890-404a-b466-c40c721fee7a", 20.0, new DateTime(2024, 5, 1, 16, 0, 59, 886, DateTimeKind.Utc).AddTicks(6769), 50000 },
                    { 3, "34e84b78-a808-42a6-bcd8-6b434e6ec1a1", 15.0, new DateTime(2024, 5, 1, 16, 0, 59, 886, DateTimeKind.Utc).AddTicks(6783), 25000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
