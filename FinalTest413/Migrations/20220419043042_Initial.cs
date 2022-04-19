using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest413.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuoteText = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Citation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteID);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteID", "Author", "Citation", "Date", "QuoteText", "Subject" },
                values: new object[] { 1, "Virgil", "", "19 B.C.", "Fortune Favors the Bold.", "" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteID", "Author", "Citation", "Date", "QuoteText", "Subject" },
                values: new object[] { 2, "Mahatma Gandhi", "", "1913", "You must be the change you wish to see in the world.", "" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteID", "Author", "Citation", "Date", "QuoteText", "Subject" },
                values: new object[] { 3, "René Descartes", "", "1637", "I think, therefore I am.", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
