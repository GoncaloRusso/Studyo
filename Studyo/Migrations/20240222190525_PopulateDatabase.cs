using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studyo.Migrations
{
    /// <inheritdoc />
    public partial class PopulateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Existing migration code...
            var sqlScript = File.ReadAllText("./Data/PopulateDb.sql");
            migrationBuilder.Sql(sqlScript);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
