using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatTool.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RSAMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicKeyBase64",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicKeyBase64",
                table: "AspNetUsers");
        }
    }
}
