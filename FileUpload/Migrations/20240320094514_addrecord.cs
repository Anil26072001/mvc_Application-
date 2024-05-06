using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploadOperation.Migrations
{
    /// <inheritdoc />
    public partial class addrecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Files",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Files",
                newName: "Filepath");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Size",
                table: "Files",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Filepath",
                table: "Files",
                newName: "name");
        }
    }
}
