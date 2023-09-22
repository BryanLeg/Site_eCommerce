using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteECommerce_TP_.Migrations
{
    /// <inheritdoc />
    public partial class UserModelCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "u_adress",
                table: "Users",
                newName: "u_address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "u_address",
                table: "Users",
                newName: "u_adress");
        }
    }
}
