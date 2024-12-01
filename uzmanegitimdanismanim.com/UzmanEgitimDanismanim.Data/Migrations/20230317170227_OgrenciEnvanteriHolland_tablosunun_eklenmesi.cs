using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzmanEgitimDanismanim.Data.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciEnvanteriHollandtablosununeklenmesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciEnvanteriHolland",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    Soru1 = table.Column<int>(type: "int", nullable: false),
                    Soru2 = table.Column<int>(type: "int", nullable: false),
                    Soru3 = table.Column<int>(type: "int", nullable: false),
                    Soru4 = table.Column<int>(type: "int", nullable: false),
                    Soru5 = table.Column<int>(type: "int", nullable: false),
                    Soru6 = table.Column<int>(type: "int", nullable: false),
                    Soru7 = table.Column<int>(type: "int", nullable: false),
                    Soru8 = table.Column<int>(type: "int", nullable: false),
                    Soru9 = table.Column<int>(type: "int", nullable: false),
                    Soru10 = table.Column<int>(type: "int", nullable: false),
                    Soru11 = table.Column<int>(type: "int", nullable: false),
                    Soru12 = table.Column<int>(type: "int", nullable: false),
                    Soru13 = table.Column<int>(type: "int", nullable: false),
                    Soru14 = table.Column<int>(type: "int", nullable: false),
                    Soru15 = table.Column<int>(type: "int", nullable: false),
                    Soru16 = table.Column<int>(type: "int", nullable: false),
                    Soru17 = table.Column<int>(type: "int", nullable: false),
                    Soru18 = table.Column<int>(type: "int", nullable: false),
                    Soru19 = table.Column<int>(type: "int", nullable: false),
                    Soru20 = table.Column<int>(type: "int", nullable: false),
                    Soru21 = table.Column<int>(type: "int", nullable: false),
                    Soru22 = table.Column<int>(type: "int", nullable: false),
                    Soru23 = table.Column<int>(type: "int", nullable: false),
                    Soru24 = table.Column<int>(type: "int", nullable: false),
                    Soru25 = table.Column<int>(type: "int", nullable: false),
                    Soru26 = table.Column<int>(type: "int", nullable: false),
                    Soru27 = table.Column<int>(type: "int", nullable: false),
                    Soru28 = table.Column<int>(type: "int", nullable: false),
                    Soru29 = table.Column<int>(type: "int", nullable: false),
                    Soru30 = table.Column<int>(type: "int", nullable: false),
                    Soru31 = table.Column<int>(type: "int", nullable: false),
                    Soru32 = table.Column<int>(type: "int", nullable: false),
                    Soru33 = table.Column<int>(type: "int", nullable: false),
                    Soru34 = table.Column<int>(type: "int", nullable: false),
                    Soru35 = table.Column<int>(type: "int", nullable: false),
                    Soru36 = table.Column<int>(type: "int", nullable: false),
                    Soru37 = table.Column<int>(type: "int", nullable: false),
                    Soru38 = table.Column<int>(type: "int", nullable: false),
                    Soru39 = table.Column<int>(type: "int", nullable: false),
                    Soru40 = table.Column<int>(type: "int", nullable: false),
                    Soru41 = table.Column<int>(type: "int", nullable: false),
                    Soru42 = table.Column<int>(type: "int", nullable: false),
                    Soru43 = table.Column<int>(type: "int", nullable: false),
                    Soru44 = table.Column<int>(type: "int", nullable: false),
                    Soru45 = table.Column<int>(type: "int", nullable: false),
                    Soru46 = table.Column<int>(type: "int", nullable: false),
                    Soru47 = table.Column<int>(type: "int", nullable: false),
                    Soru48 = table.Column<int>(type: "int", nullable: false),
                    Soru49 = table.Column<int>(type: "int", nullable: false),
                    Soru50 = table.Column<int>(type: "int", nullable: false),
                    Soru51 = table.Column<int>(type: "int", nullable: false),
                    Soru52 = table.Column<int>(type: "int", nullable: false),
                    Soru53 = table.Column<int>(type: "int", nullable: false),
                    Soru54 = table.Column<int>(type: "int", nullable: false),
                    Soru55 = table.Column<int>(type: "int", nullable: false),
                    Soru56 = table.Column<int>(type: "int", nullable: false),
                    Soru57 = table.Column<int>(type: "int", nullable: false),
                    Soru58 = table.Column<int>(type: "int", nullable: false),
                    Soru59 = table.Column<int>(type: "int", nullable: false),
                    Soru60 = table.Column<int>(type: "int", nullable: false),
                    Soru61 = table.Column<int>(type: "int", nullable: false),
                    Soru62 = table.Column<int>(type: "int", nullable: false),
                    Soru63 = table.Column<int>(type: "int", nullable: false),
                    Soru64 = table.Column<int>(type: "int", nullable: false),
                    Soru65 = table.Column<int>(type: "int", nullable: false),
                    Soru66 = table.Column<int>(type: "int", nullable: false),
                    Soru67 = table.Column<int>(type: "int", nullable: false),
                    Soru68 = table.Column<int>(type: "int", nullable: false),
                    Soru69 = table.Column<int>(type: "int", nullable: false),
                    Soru70 = table.Column<int>(type: "int", nullable: false),
                    Soru71 = table.Column<int>(type: "int", nullable: false),
                    Soru72 = table.Column<int>(type: "int", nullable: false),
                    Soru73 = table.Column<int>(type: "int", nullable: false),
                    Soru74 = table.Column<int>(type: "int", nullable: false),
                    Soru75 = table.Column<int>(type: "int", nullable: false),
                    Soru76 = table.Column<int>(type: "int", nullable: false),
                    Soru77 = table.Column<int>(type: "int", nullable: false),
                    Soru78 = table.Column<int>(type: "int", nullable: false),
                    Soru79 = table.Column<int>(type: "int", nullable: false),
                    Soru80 = table.Column<int>(type: "int", nullable: false),
                    Soru81 = table.Column<int>(type: "int", nullable: false),
                    Soru82 = table.Column<int>(type: "int", nullable: false),
                    Soru83 = table.Column<int>(type: "int", nullable: false),
                    Soru84 = table.Column<int>(type: "int", nullable: false),
                    Soru85 = table.Column<int>(type: "int", nullable: false),
                    Soru86 = table.Column<int>(type: "int", nullable: false),
                    Soru87 = table.Column<int>(type: "int", nullable: false),
                    Soru88 = table.Column<int>(type: "int", nullable: false),
                    Soru89 = table.Column<int>(type: "int", nullable: false),
                    Soru90 = table.Column<int>(type: "int", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsleYapanKullanici = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciEnvanteriHolland", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciEnvanteriHolland_Kullanici_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciEnvanteriHolland_OgrenciId",
                table: "OgrenciEnvanteriHolland",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciEnvanteriHolland");
        }
    }
}
