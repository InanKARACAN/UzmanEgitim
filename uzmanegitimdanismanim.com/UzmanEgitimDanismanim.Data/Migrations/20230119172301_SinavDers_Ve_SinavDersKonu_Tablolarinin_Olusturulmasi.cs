using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class SinavDersVeSinavDersKonuTablolarininOlusturulmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinavDers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavId = table.Column<int>(type: "int", nullable: false),
                    SinavDersAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinavDers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinavDers_Sinav_SinavId",
                        column: x => x.SinavId,
                        principalTable: "Sinav",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinavDersKonu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavDersId = table.Column<int>(type: "int", nullable: false),
                    SinavDersKonuAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinavDersKonu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinavDersKonu_SinavDers_SinavDersId",
                        column: x => x.SinavDersId,
                        principalTable: "SinavDers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinavDers_SinavId",
                table: "SinavDers",
                column: "SinavId");

            migrationBuilder.CreateIndex(
                name: "IX_SinavDersKonu_SinavDersId",
                table: "SinavDersKonu",
                column: "SinavDersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinavDersKonu");

            migrationBuilder.DropTable(
                name: "SinavDers");
        }
    }
}
