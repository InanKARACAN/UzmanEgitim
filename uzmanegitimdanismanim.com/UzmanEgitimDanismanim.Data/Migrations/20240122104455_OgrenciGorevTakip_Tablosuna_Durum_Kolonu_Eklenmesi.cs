using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciGorevTakipTablosunaDurumKolonuEklenmesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Durum",
                table: "OgrenciGorevTakip",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "OgrenciGorevTakip");
        }
    }
}
