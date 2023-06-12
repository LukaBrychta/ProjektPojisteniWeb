using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencePojisteniPlnaVerze.Data.Migrations
{
    /// <inheritdoc />
    public partial class tabulka3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Insured_InsuredId",
                table: "Insurance");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredId",
                table: "Insurance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Insured_InsuredId",
                table: "Insurance",
                column: "InsuredId",
                principalTable: "Insured",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Insured_InsuredId",
                table: "Insurance");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredId",
                table: "Insurance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Insured_InsuredId",
                table: "Insurance",
                column: "InsuredId",
                principalTable: "Insured",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
