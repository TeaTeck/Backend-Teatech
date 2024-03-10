using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "child_assisted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FoodSelectivity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aversions = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Preferences = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MedicalRecord = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Responsible_id = table.Column<int>(type: "integer", nullable: false),
                    Photo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child_assisted", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "child_assisted");
        }
    }
}
