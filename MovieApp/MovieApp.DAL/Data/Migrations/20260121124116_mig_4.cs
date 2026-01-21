using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Duration", "Imdb", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "A mind-bending thriller about dream invasion.", 1, 148, 8.8m, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, "Batman faces the Joker in Gotham City.", 1, 152, 9.0m, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 3, "Interwoven stories of crime in Los Angeles.", 2, 154, 8.9m, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { 4, "A bride seeks revenge on her former lover.", 2, 111, 8.1m, new DateTime(2003, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kill Bill: Vol. 1" },
                    { 5, "The life journey of a simple man with a big heart.", 3, 142, 8.8m, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { 6, "A WWII mission to save a paratrooper behind enemy lines.", 4, 169, 8.6m, new DateTime(1998, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saving Private Ryan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Director_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Director_DirectorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movies");
        }
    }
}
