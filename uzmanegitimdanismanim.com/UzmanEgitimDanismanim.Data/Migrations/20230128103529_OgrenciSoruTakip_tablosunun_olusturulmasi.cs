using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciSoruTakiptablosununolusturulmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciSoruTakip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    SinifDersKonuId = table.Column<int>(type: "int", nullable: false),
                    CozumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSoruTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSoruTakip_Kullanici_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciSoruTakip_SinifDersKonu_SinifDersKonuId",
                        column: x => x.SinifDersKonuId,
                        principalTable: "SinifDersKonu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSoruTakip_OgrenciId",
                table: "OgrenciSoruTakip",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSoruTakip_SinifDersKonuId",
                table: "OgrenciSoruTakip",
                column: "SinifDersKonuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciSoruTakip");
        }
    }
}
