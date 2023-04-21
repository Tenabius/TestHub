using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MatchingQuestionChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stem_Response_ResponseId",
                table: "Stem");

            migrationBuilder.DropIndex(
                name: "IX_Stem_ResponseId",
                table: "Stem");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "Stem");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Response",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MatchingQuestionId",
                table: "Response",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Response_MatchingQuestionId",
                table: "Response",
                column: "MatchingQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_MatchingQuestion_MatchingQuestionId",
                table: "Response",
                column: "MatchingQuestionId",
                principalTable: "MatchingQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Stem_Id",
                table: "Response",
                column: "Id",
                principalTable: "Stem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_MatchingQuestion_MatchingQuestionId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Stem_Id",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_MatchingQuestionId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "MatchingQuestionId",
                table: "Response");

            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "Stem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Response",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Stem_ResponseId",
                table: "Stem",
                column: "ResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stem_Response_ResponseId",
                table: "Stem",
                column: "ResponseId",
                principalTable: "Response",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
