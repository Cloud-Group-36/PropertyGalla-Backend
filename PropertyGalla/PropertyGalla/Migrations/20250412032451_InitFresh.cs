using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyGalla.Migrations
{
    /// <inheritdoc />
    public partial class InitFresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCarts",
                columns: table => new
                {
                    CartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCarts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_UserCarts_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCarts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_PropertyId",
                table: "UserCarts",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_UserId",
                table: "UserCarts",
                column: "UserId");
        }
    }
}
