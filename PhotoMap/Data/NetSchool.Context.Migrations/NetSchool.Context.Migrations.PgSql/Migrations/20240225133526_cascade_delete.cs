using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSchool.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class cascade_delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_points_PointId",
                table: "feedbacks");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_points_PointId",
                table: "feedbacks",
                column: "PointId",
                principalTable: "points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_points_PointId",
                table: "feedbacks");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_points_PointId",
                table: "feedbacks",
                column: "PointId",
                principalTable: "points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
