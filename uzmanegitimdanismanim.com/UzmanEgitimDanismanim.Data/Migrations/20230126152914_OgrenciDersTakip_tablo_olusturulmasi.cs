using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciDersTakiptabloolusturulmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciDersTakip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    SinifDersKonuId = table.Column<int>(type: "int", nullable: false),
                    CalismaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalismaSuresi = table.Column<int>(type: "int", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDersTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciDersTakip_Kullanici_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDersTakip_SinifDersKonu_SinifDersKonuId",
                        column: x => x.SinifDersKonuId,
                        principalTable: "SinifDersKonu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDersTakip_OgrenciId",
                table: "OgrenciDersTakip",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDersTakip_SinifDersKonuId",
                table: "OgrenciDersTakip",
                column: "SinifDersKonuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciDersTakip");
        }
    }
}
