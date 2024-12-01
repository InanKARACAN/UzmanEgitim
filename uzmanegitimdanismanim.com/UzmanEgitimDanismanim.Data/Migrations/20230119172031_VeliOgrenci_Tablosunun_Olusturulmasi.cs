using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class VeliOgrenciTablosununOlusturulmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeliOgrenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeliId = table.Column<int>(type: "int", nullable: false),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeliOgrenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeliOgrenci_Kullanici_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeliOgrenci_Kullanici_VeliId",
                        column: x => x.VeliId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeliOgrenci_OgrenciId",
                table: "VeliOgrenci",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_VeliOgrenci_VeliId",
                table: "VeliOgrenci",
                column: "VeliId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeliOgrenci");
        }
    }
}
