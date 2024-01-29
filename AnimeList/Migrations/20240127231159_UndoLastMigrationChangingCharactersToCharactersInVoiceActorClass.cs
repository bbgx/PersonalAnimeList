using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class UndoLastMigrationChangingCharactersToCharactersInVoiceActorClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterModelVoiceActor_Characters_CharactersId",
                table: "CharacterModelVoiceActor");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterModelVoiceActor",
                newName: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterModelVoiceActor_Characters_CharacterId",
                table: "CharacterModelVoiceActor",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterModelVoiceActor_Characters_CharacterId",
                table: "CharacterModelVoiceActor");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterModelVoiceActor",
                newName: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterModelVoiceActor_Characters_CharactersId",
                table: "CharacterModelVoiceActor",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
