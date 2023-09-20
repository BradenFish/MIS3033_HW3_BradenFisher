using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS3033_HW3_BradenFisher.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receiptTbl",
                columns: table => new
                {
                    ReceiptID = table.Column<string>(type: "TEXT", nullable: false),
                    CogQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    GearQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receiptTbl", x => x.ReceiptID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receiptTbl");
        }
    }
}
