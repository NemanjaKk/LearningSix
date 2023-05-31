using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSix.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtColumnToCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Characters",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Characters");
        }
    }
}
