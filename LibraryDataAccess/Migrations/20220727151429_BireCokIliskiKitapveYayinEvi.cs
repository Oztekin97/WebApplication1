using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class BireCokIliskiKitapveYayinEvi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YayinEviId",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_YayinEviId",
                table: "Kitap",
                column: "YayinEviId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_YayinEvi_YayinEviId",
                table: "Kitap",
                column: "YayinEviId",
                principalTable: "YayinEvi",
                principalColumn: "YayinEviId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_YayinEvi_YayinEviId",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_YayinEviId",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "YayinEviId",
                table: "Kitap");
        }
    }
}
