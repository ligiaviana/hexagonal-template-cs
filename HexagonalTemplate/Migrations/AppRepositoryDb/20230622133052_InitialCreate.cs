using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HexagonalTemplate.Migrations.AppRepositoryDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveChannels",
                columns: table => new
                {
                    ActiveChannelsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WebPush = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sms = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveChannels", x => x.ActiveChannelsId);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.AppId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveChannels");

            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
