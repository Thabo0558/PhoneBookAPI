using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "PhoneBook", columns: t => new
            {
                Id = t.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = t.Column<string>(nullable: false, maxLength: 100)
            },
            constraints: t =>
            {
                t.PrimaryKey("PK_PhoneBook", k => k.Id);
            });

            migrationBuilder.CreateTable(name: "PhonebookEntry", columns: t => new
            {
                Id = t.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                PhoneBookId = t.Column<int>(nullable: false),
                Name = t.Column<string>(nullable: false, maxLength: 100),
                PhoneNumber = t.Column<string>(nullable: true, maxLength: 20)

            },
            constraints: t =>
            {
                t.PrimaryKey("PK_Entry", k => k.Id);
                t.ForeignKey(
                    name: "FK_Entry_PhoneBook_PhoneBookId",
                    column: x => x.PhoneBookId,
                    principalTable: "PhoneBook",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PhoneBookId",
                table: "Entry",
                column: "PhoneBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhonebookEntry");

            migrationBuilder.DropTable(
                name: "PhoneBook");
        }
    }
}
