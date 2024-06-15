using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDApp.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_DistrictId",
                table: "Customers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MunicipalityId",
                table: "Customers",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Districts_DistrictId",
                table: "Customers",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Municipalities_MunicipalityId",
                table: "Customers",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "MunId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Provinces_ProvinceId",
                table: "Customers",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Districts_DistrictId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Municipalities_MunicipalityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Provinces_ProvinceId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DistrictId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MunicipalityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers");
        }
    }
}
