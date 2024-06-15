using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "WardNo",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Municipality",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "WardNo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
