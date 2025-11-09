using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PDFShelf.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddStorageMBToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorageUsedMB",
                table: "Users",
                newName: "UsedStorageMB");

            migrationBuilder.CreateTable(
                name: "PdfFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId2 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId3 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfFile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PdfFile_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PdfFile_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PdfFile_Users_UserId3",
                        column: x => x.UserId3,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_UserId",
                table: "PdfFile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_UserId1",
                table: "PdfFile",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_UserId2",
                table: "PdfFile",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_PdfFile_UserId3",
                table: "PdfFile",
                column: "UserId3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfFile");

            migrationBuilder.RenameColumn(
                name: "UsedStorageMB",
                table: "Users",
                newName: "StorageUsedMB");
        }
    }
}
