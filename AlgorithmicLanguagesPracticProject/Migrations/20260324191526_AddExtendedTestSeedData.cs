using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlgorithmicLanguagesPracticProject.Migrations
{
    /// <inheritdoc />
    public partial class AddExtendedTestSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "MediaId", "UserId" },
                values: new object[] { 2, "Сюжет тримає в напрузі до кінця.", new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2, 2 });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "Description", "Rating", "ReleaseYear", "StudioId", "Title" },
                values: new object[] { 3, "Епічна фантастична історія про боротьбу за Арракіс.", 8.0, 2021, 1, "Dune" });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 3, "USA", "Pixar" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 2, "user1@local", "5gbjiw2MGbJM8O44CBgxYup81j/3kS27IrXoAyhrREY=", "User", "user1" },
                    { 3, "user2@local", "k36NX7tIvUlJU2zWW401xCa4DS+DDFwwjizexCKuIkQ=", "User", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "MediaId", "UserId" },
                values: new object[] { 3, "Візуал і музика просто чудові.", new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), 3, 3 });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "Description", "Rating", "ReleaseYear", "StudioId", "Title" },
                values: new object[] { 4, "Анімаційний фільм про сенс життя та музику.", 8.0999999999999996, 2020, 3, "Soul" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "MediaId", "UserId" },
                values: new object[] { 4, "Дуже теплий і мотиваційний мультфільм.", new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 4, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
