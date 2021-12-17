using Microsoft.EntityFrameworkCore.Migrations;

namespace ProposalDemo.DataAccess.Migrations
{
    public partial class AddDatabaseNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProductProposalInfo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductProposalInfo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductProposalInfo");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ProductProposalInfo",
                newName: "Response");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Response",
                table: "ProductProposalInfo",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProductProposalInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductProposalInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductProposalInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
