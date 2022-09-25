using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class EkleYayinEviveYazarTablolariDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YayinEvi",
                columns: table => new
                {
                    YayinEviId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasimYeri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEvi", x => x.YayinEviId);
                });

            migrationBuilder.CreateTable(
                name: "Yazar",
                columns: table => new
                {
                    YazarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazar", x => x.YazarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YayinEvi");

            migrationBuilder.DropTable(
                name: "Yazar");
        }
    }
}
