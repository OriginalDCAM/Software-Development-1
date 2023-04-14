using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp.Migrations
{
    public partial class added_authors_and_books_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "British author", "J.K. Rowling" },
                    { 2, "British author", "J.R.R. Tolkien" },
                    { 3, "American author", "George R.R. Martin" },
                    { 4, "American author", "Stephen King" },
                    { 5, "British author", "Agatha Christie" },
                    { 6, "English novelist", "Jane Austen" },
                    { 7, "Russian writer", "Leo Tolstoy" },
                    { 8, "Russian novelist", "Fyodor Dostoevsky" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "Name" },
                values: new object[,]
                {
                    { 1, 1, "First book in the Harry Potter series", 3, "Harry Potter and the Philosopher's Stone" },
                    { 9, 1, "Second book in the Harry Potter series", 3, "Harry Potter and the Chambers of Secrets" },
                    { 2, 2, "Epic high-fantasy novel", 3, "The Lord of the Rings" },
                    { 3, 3, "First book in the A Song of Ice and Fire series", 3, "A Game of Thrones" },
                    { 4, 4, "Horror novel", 4, "The Shining" },
                    { 5, 5, "Detective novel", 6, "Murder on the Orient Express" },
                    { 6, 6, "Novel of manners", 7, "Pride and Prejudice" },
                    { 7, 7, "Historical novel", 1, "War and Peace" },
                    { 8, 8, "Psychological thriller", 2, "Crime and Punishment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name",
                table: "Authors",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Name",
                table: "Books",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
