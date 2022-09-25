using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class EkleBirebirIliskiKitapDetayiveKitap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitapDetayId",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KitapDetaylari",
                columns: table => new
                {
                    KitapDetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    KitapSayfaSayisi = table.Column<int>(type: "int", nullable: false),
                    agirlik = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapDetaylari", x => x.KitapDetayId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KitapDetayId",
                table: "Kitap",
                column: "KitapDetayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_KitapDetaylari_KitapDetayId",
                table: "Kitap",
                column: "KitapDetayId",
                principalTable: "KitapDetaylari",
                principalColumn: "KitapDetayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetaylari_KitapDetayId",
                table: "Kitap");

            migrationBuilder.DropTable(
                name: "KitapDetaylari");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KitapDetayId",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "KitapDetayId",
                table: "Kitap");
        }
    }
}
