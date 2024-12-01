using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class SinavDersKonukonuisimlerininsinirartirilmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SinavDersKonuAdi",
                table: "SinavDersKonu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SinavDersKonuAdi",
                table: "SinavDersKonu",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
