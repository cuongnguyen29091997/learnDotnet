using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BookStore.Migrations
{
    public partial class InitApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    author = table.Column<string>(unicode: false, maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    title = table.Column<string>(unicode: false, maxLength: 500, nullable: true, defaultValueSql: "'NULL'"),
                    description = table.Column<string>(unicode: false, maxLength: 1000, nullable: true, defaultValueSql: "'NULL'"),
                    price = table.Column<float>(nullable: false, defaultValue: 0),
                    discountedPrice = table.Column<float>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categorybook",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int(11)", nullable: false),
                    categoryId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.bookId, x.categoryId });
                    table.ForeignKey(
                        name: "FK_CategoryBook_Book",
                        column: x => x.bookId,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBook_Category",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FK_CategoryBook_Category",
                table: "categorybook",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorybook");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
