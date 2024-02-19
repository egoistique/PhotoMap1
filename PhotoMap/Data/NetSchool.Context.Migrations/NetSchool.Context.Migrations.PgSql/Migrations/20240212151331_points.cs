using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetSchool.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class points : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "point_categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PointCategoryId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_points_point_categories_PointCategoryId",
                        column: x => x.PointCategoryId,
                        principalTable: "point_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: false),
                    PointId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feedbacks_points_PointId",
                        column: x => x.PointId,
                        principalTable: "points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "image_pathes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PointId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image_pathes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_image_pathes_points_PointId",
                        column: x => x.PointId,
                        principalTable: "points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_PointId",
                table: "feedbacks",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_Uid",
                table: "feedbacks",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_pathes_PointId",
                table: "image_pathes",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_image_pathes_Uid",
                table: "image_pathes",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_point_categories_Title",
                table: "point_categories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_point_categories_Uid",
                table: "point_categories",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_points_PointCategoryId",
                table: "points",
                column: "PointCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_points_Uid",
                table: "points",
                column: "Uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "image_pathes");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "point_categories");
        }
    }
}
