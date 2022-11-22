using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shipping.Migrations
{
    public partial class Firstt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    CarrierId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.CarrierId);
                });

            migrationBuilder.CreateTable(
                name: "CarrierServices",
                columns: table => new
                {
                    ShippingServiceId = table.Column<string>(type: "text", nullable: false),
                    CarrierId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierServices", x => x.ShippingServiceId);
                    table.ForeignKey(
                        name: "FK_CarrierServices_ServiceProviders_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "ServiceProviders",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    ShippingServiceId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_CarrierServices_ShippingServiceId",
                        column: x => x.ShippingServiceId,
                        principalTable: "CarrierServices",
                        principalColumn: "ShippingServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrierServices_CarrierId",
                table: "CarrierServices",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ShippingServiceId",
                table: "Packages",
                column: "ShippingServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "CarrierServices");

            migrationBuilder.DropTable(
                name: "ServiceProviders");
        }
    }
}
