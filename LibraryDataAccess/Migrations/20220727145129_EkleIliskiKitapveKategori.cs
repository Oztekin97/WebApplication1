using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class EkleIliskiKitapveKategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Kategoriler_KategoriId",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KategoriId",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Kitap");
        }
    }
}
