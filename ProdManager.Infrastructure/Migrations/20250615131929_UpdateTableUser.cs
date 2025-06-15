using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TB_User_Email",
                table: "TB_User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_User_Registration",
                table: "TB_User",
                column: "Registration",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_User_Email",
                table: "TB_User");

            migrationBuilder.DropIndex(
                name: "IX_TB_User_Registration",
                table: "TB_User");
        }
    }
}
