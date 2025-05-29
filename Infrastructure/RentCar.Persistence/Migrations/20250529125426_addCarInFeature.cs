using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addCarInFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Cars");
        }
    }
}
