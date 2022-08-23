using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dictionarythesaurus.Migrations
{
    public partial class AddedPartOfSpeech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartOfSpeech",
                table: "Definition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "Definition");
        }
    }
}
