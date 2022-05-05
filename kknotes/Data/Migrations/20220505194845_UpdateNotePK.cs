using Microsoft.EntityFrameworkCore.Migrations;

namespace kknotes.Data.Migrations
{
    public partial class UpdateNotePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notes",
                newName: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Notes",
                newName: "Id");
        }
    }
}
