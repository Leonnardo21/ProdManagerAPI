using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Registration",
                table: "Tb_User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_User_Registration",
                table: "Tb_User",
                column: "Registration",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tb_User_Registration",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "Registration",
                table: "Tb_User");
        }
    }
}
