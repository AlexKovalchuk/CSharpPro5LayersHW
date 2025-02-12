using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalOwnerEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalsOwners",
                schema: "animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalsOwners", x => new { x.AnimalId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_AnimalsOwners_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "animals",
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalsOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "animals",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsOwners_OwnerId",
                schema: "animals",
                table: "AnimalsOwners",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalsOwners",
                schema: "animals");
        }
    }
}
