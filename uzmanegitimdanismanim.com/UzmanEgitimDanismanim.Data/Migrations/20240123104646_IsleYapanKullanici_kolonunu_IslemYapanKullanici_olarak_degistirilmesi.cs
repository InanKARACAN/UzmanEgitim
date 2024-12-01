using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsleYapanKullanicikolonunuIslemYapanKullaniciolarakdegistirilmesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "VeliOgrenci",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "SinifDersKonu",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "SinifDers",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "Sinif",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "SinavDersKonu",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "SinavDers",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "Sinav",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciSoruTakip",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciSinif",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciSinavTakipCozum",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciSinavTakip",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciKendiniDegerlendirme",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciGorevTakip",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciEnvanteriHolland",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciDokuman",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "OgrenciDersTakip",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "Kurum",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "KullaniciRol",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "Kullanici",
                newName: "IslemYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IsleYapanKullanici",
                table: "DanismanOgrenci",
                newName: "IslemYapanKullanici");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "VeliOgrenci",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "SinifDersKonu",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "SinifDers",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "Sinif",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "SinavDersKonu",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "SinavDers",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "Sinav",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciSoruTakip",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciSinif",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciSinavTakipCozum",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciSinavTakip",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciKendiniDegerlendirme",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciGorevTakip",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciEnvanteriHolland",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciDokuman",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "OgrenciDersTakip",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "Kurum",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "KullaniciRol",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "Kullanici",
                newName: "IsleYapanKullanici");

            migrationBuilder.RenameColumn(
                name: "IslemYapanKullanici",
                table: "DanismanOgrenci",
                newName: "IsleYapanKullanici");
        }
    }
}
