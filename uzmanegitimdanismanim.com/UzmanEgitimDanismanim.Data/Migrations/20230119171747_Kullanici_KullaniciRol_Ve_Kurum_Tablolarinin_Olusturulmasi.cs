using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class KullaniciKullaniciRolVeKurumTablolarininOlusturulmasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kurum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KurumAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    KurumEposta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KurumTel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KurumAdres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KurumId = table.Column<int>(type: "int", nullable: false),
                    KullaniciRolId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CepTelefonu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SonGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanici_KullaniciRol_KullaniciRolId",
                        column: x => x.KullaniciRolId,
                        principalTable: "KullaniciRol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kullanici_Kurum_KurumId",
                        column: x => x.KurumId,
                        principalTable: "Kurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_KullaniciRolId",
                table: "Kullanici",
                column: "KullaniciRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_KurumId",
                table: "Kullanici",
                column: "KurumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropTable(
                name: "Kurum");
        }
    }
}
