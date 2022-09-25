using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDataAccess.Migrations
{
    public partial class EkleHamVeriKategoriTablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Roman')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Hikaye')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Deneme')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Makale')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Ansiklopedi')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Şiir')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Ders Kitabı')");
            migrationBuilder.Sql("INSERT INTO Kategoriler VALUES('Yabancı Dil')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
