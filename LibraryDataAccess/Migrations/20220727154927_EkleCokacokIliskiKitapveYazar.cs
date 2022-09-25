using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class EkleCokacokIliskiKitapveYazar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Kategoriler_KategoriId",
                table: "Kitap");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KategoriId",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Kitap");

            migrationBuilder.CreateTable(
                name: "KitapYazarlar",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazarlar", x => new { x.YazarId, x.KitapId });
                    table.ForeignKey(
                        name: "FK_KitapYazarlar_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "KitapId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazarlar_Yazar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazar",
                        principalColumn: "YazarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazarlar_KitapId",
                table: "KitapYazarlar",
                column: "KitapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapYazarlar");

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KategoriId",
                table: "Kitap",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Kategoriler_KategoriId",
                table: "Kitap",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
