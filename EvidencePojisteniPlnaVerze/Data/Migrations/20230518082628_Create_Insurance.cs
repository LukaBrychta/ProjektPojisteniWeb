using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencePojisteniPlnaVerze.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Insurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameInsurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectInsurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeInsurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_Insured_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Insured",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_InsuredId",
                table: "Insurance",
                column: "InsuredId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}
