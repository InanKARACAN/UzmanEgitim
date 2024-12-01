using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class ogrencisinavtakipveogrencisinavtakipcozumtablolarinineklenmesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciSinavTakip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    SinavId = table.Column<int>(type: "int", nullable: false),
                    SinavAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZorlukSeviyesi = table.Column<byte>(type: "tinyint", nullable: false),
                    CozumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSinavTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSinavTakip_Kullanici_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciSinavTakip_Sinav_SinavId",
                        column: x => x.SinavId,
                        principalTable: "Sinav",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSinavTakipCozum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciSinavTakipId = table.Column<int>(type: "int", nullable: false),
                    SinavDersId = table.Column<int>(type: "int", nullable: false),
                    Dogru = table.Column<int>(type: "int", nullable: false),
                    Yanlis = table.Column<int>(type: "int", nullable: false),
                    Bos = table.Column<int>(type: "int", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSinavTakipCozum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSinavTakipCozum_OgrenciSinavTakip_OgrenciSinavTakipId",
                        column: x => x.OgrenciSinavTakipId,
                        principalTable: "OgrenciSinavTakip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciSinavTakipCozum_SinavDers_SinavDersId",
                        column: x => x.SinavDersId,
                        principalTable: "SinavDers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSinavTakip_OgrenciId",
                table: "OgrenciSinavTakip",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSinavTakip_SinavId",
                table: "OgrenciSinavTakip",
                column: "SinavId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSinavTakipCozum_OgrenciSinavTakipId",
                table: "OgrenciSinavTakipCozum",
                column: "OgrenciSinavTakipId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSinavTakipCozum_SinavDersId",
                table: "OgrenciSinavTakipCozum",
                column: "SinavDersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciSinavTakipCozum");

            migrationBuilder.DropTable(
                name: "OgrenciSinavTakip");
        }
    }
}
