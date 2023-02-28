using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShelter.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableFundraiser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FundraiserId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fundraisers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundraisers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_FundraiserId",
                table: "Donations",
                column: "FundraiserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Fundraisers_FundraiserId",
                table: "Donations",
                column: "FundraiserId",
                principalTable: "Fundraisers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Fundraisers_FundraiserId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Fundraisers");

            migrationBuilder.DropIndex(
                name: "IX_Donations_FundraiserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "FundraiserId",
                table: "Donations");
        }
    }
}
