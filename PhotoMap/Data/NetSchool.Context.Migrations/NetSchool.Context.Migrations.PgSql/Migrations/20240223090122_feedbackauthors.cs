using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSchool.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class feedbackauthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeedbackAuthor",
                table: "feedbacks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackAuthor",
                table: "feedbacks");
        }
    }
}
