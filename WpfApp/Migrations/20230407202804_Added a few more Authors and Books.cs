using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp.Migrations
{
    public partial class AddedafewmoreAuthorsandBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "English novelist", "Jane Austen" },
                    { 7, "Russian writer", "Leo Tolstoy" },
                    { 8, "Russian novelist", "Fyodor Dostoevsky" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "Name" },
                values: new object[] { 9, 1, "Second book in the Harry Potter series", 3, "Harry Potter and the Chambers of Secrets" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "Name" },
                values: new object[] { 6, 6, "Novel of manners", 7, "Pride and Prejudice" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "Name" },
                values: new object[] { 7, 7, "Historical novel", 1, "War and Peace" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "Name" },
                values: new object[] { 8, 8, "Psychological thriller", 2, "Crime and Punishment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
