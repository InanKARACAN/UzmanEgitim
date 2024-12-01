using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciGorevTakiptablosueklenmesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciGorevTakip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GorevBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GorevBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TumGun = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciGorevTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciGorevTakip_Kullanici_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciGorevTakip_OgrenciId",
                table: "OgrenciGorevTakip",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciGorevTakip");
        }
    }
}
