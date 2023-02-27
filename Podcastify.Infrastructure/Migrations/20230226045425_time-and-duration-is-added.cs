using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Podcastify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class timeanddurationisadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Podcasts",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "EpisodeNumber",
                table: "Podcasts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Podcasts");

            migrationBuilder.DropColumn(
                name: "EpisodeNumber",
                table: "Podcasts");
        }
    }
}
