using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecievedData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationCode = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Speed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SendNumber = table.Column<long>(type: "bigint", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutiveOperationCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecievedData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecievedData");
        }
    }
}
