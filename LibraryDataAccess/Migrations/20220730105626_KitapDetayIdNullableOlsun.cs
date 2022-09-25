using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class KitapDetayIdNullableOlsun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetaylari_KitapDetayId",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KitapDetayId",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KitapDetayId",
                table: "Kitap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KitapDetayId",
                table: "Kitap",
                column: "KitapDetayId",
                unique: true,
                filter: "[KitapDetayId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_KitapDetaylari_KitapDetayId",
                table: "Kitap",
                column: "KitapDetayId",
                principalTable: "KitapDetaylari",
                principalColumn: "KitapDetayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetaylari_KitapDetayId",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KitapDetayId",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KitapDetayId",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
