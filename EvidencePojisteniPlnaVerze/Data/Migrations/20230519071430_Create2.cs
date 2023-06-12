﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidencePojisteniPlnaVerze.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Insured_InsuredId",
                table: "Insurance");

            migrationBuilder.RenameColumn(
                name: "InsuredId",
                table: "Insurance",
                newName: "InsuredID");

            migrationBuilder.RenameIndex(
                name: "IX_Insurance_InsuredId",
                table: "Insurance",
                newName: "IX_Insurance_InsuredID");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredID",
                table: "Insurance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Insured_InsuredID",
                table: "Insurance",
                column: "InsuredID",
                principalTable: "Insured",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Insured_InsuredID",
                table: "Insurance");

            migrationBuilder.RenameColumn(
                name: "InsuredID",
                table: "Insurance",
                newName: "InsuredId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurance_InsuredID",
                table: "Insurance",
                newName: "IX_Insurance_InsuredId");

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
    }
}
