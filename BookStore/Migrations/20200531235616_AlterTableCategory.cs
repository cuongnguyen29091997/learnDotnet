using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class AlterTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "category",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_CategoryID",
                table: "category",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_CategoryID",
                table: "category",
                column: "CategoryID",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_CategoryID",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_CategoryID",
                table: "category");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "category");
        }
    }
}
