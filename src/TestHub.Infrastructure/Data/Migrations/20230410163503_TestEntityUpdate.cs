using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedBlank_FillBlankAnswer_FillBlankAnswerId",
                table: "SubmittedBlank");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedChoice_MultipleChoiceAnswer_MultipleChoiceAnswerId",
                table: "SubmittedChoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedResponse_MatchingAnswer_MatchingAnswerId",
                table: "SubmittedResponse");

            migrationBuilder.DropTable(
                name: "FalseTrueAnswer");

            migrationBuilder.DropTable(
                name: "FillBlankAnswer");

            migrationBuilder.DropTable(
                name: "MatchingAnswer");

            migrationBuilder.DropTable(
                name: "MultipleChoiceAnswer");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.RenameColumn(
                name: "MatchingAnswerId",
                table: "SubmittedResponse",
                newName: "MatchingCandidateAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubmittedResponse_MatchingAnswerId",
                table: "SubmittedResponse",
                newName: "IX_SubmittedResponse_MatchingCandidateAnswerId");

            migrationBuilder.RenameColumn(
                name: "MultipleChoiceAnswerId",
                table: "SubmittedChoice",
                newName: "MultipleChoiceCandidateAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubmittedChoice_MultipleChoiceAnswerId",
                table: "SubmittedChoice",
                newName: "IX_SubmittedChoice_MultipleChoiceCandidateAnswerId");

            migrationBuilder.RenameColumn(
                name: "FillBlankAnswerId",
                table: "SubmittedBlank",
                newName: "FillBlankCandidateAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubmittedBlank_FillBlankAnswerId",
                table: "SubmittedBlank",
                newName: "IX_SubmittedBlank_FillBlankCandidateAnswerId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "AnswersSheets",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateTable(
                name: "CandidateAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TestResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAnswer_AnswersSheets_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "AnswersSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FalseTrueCandidateAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubmittedChoice = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FalseTrueCandidateAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FalseTrueCandidateAnswer_CandidateAnswer_Id",
                        column: x => x.Id,
                        principalTable: "CandidateAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillBlankCandidateAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillBlankCandidateAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillBlankCandidateAnswer_CandidateAnswer_Id",
                        column: x => x.Id,
                        principalTable: "CandidateAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingCandidateAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingCandidateAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchingCandidateAnswer_CandidateAnswer_Id",
                        column: x => x.Id,
                        principalTable: "CandidateAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceCandidateAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceCandidateAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceCandidateAnswer_CandidateAnswer_Id",
                        column: x => x.Id,
                        principalTable: "CandidateAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnswer_QuestionId",
                table: "CandidateAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnswer_TestResultId",
                table: "CandidateAnswer",
                column: "TestResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedBlank_FillBlankCandidateAnswer_FillBlankCandidateAnswerId",
                table: "SubmittedBlank",
                column: "FillBlankCandidateAnswerId",
                principalTable: "FillBlankCandidateAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedChoice_MultipleChoiceCandidateAnswer_MultipleChoiceCandidateAnswerId",
                table: "SubmittedChoice",
                column: "MultipleChoiceCandidateAnswerId",
                principalTable: "MultipleChoiceCandidateAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedResponse_MatchingCandidateAnswer_MatchingCandidateAnswerId",
                table: "SubmittedResponse",
                column: "MatchingCandidateAnswerId",
                principalTable: "MatchingCandidateAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedBlank_FillBlankCandidateAnswer_FillBlankCandidateAnswerId",
                table: "SubmittedBlank");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedChoice_MultipleChoiceCandidateAnswer_MultipleChoiceCandidateAnswerId",
                table: "SubmittedChoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedResponse_MatchingCandidateAnswer_MatchingCandidateAnswerId",
                table: "SubmittedResponse");

            migrationBuilder.DropTable(
                name: "FalseTrueCandidateAnswer");

            migrationBuilder.DropTable(
                name: "FillBlankCandidateAnswer");

            migrationBuilder.DropTable(
                name: "MatchingCandidateAnswer");

            migrationBuilder.DropTable(
                name: "MultipleChoiceCandidateAnswer");

            migrationBuilder.DropTable(
                name: "CandidateAnswer");

            migrationBuilder.RenameColumn(
                name: "MatchingCandidateAnswerId",
                table: "SubmittedResponse",
                newName: "MatchingAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubmittedResponse_MatchingCandidateAnswerId",
                table: "SubmittedResponse",
                newName: "IX_SubmittedResponse_MatchingAnswerId");

            migrationBuilder.RenameColumn(
                name: "MultipleChoiceCandidateAnswerId",
                table: "SubmittedChoice",
                newName: "MultipleChoiceAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubmittedChoice_MultipleChoiceCandidateAnswerId",
                table: "SubmittedChoice",
                newName: "IX_SubmittedChoice_MultipleChoiceAnswerId");

            migrationBuilder.RenameColumn(
                name: "FillBlankCandidateAnswerId",
                table: "SubmittedBlank",
                newName: "FillBlankAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubmittedBlank_FillBlankCandidateAnswerId",
                table: "SubmittedBlank",
                newName: "IX_SubmittedBlank_FillBlankAnswerId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "AnswersSheets",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswersSheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_AnswersSheets_AnswersSheetId",
                        column: x => x.AnswersSheetId,
                        principalTable: "AnswersSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FalseTrueAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubmittedChoice = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FalseTrueAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FalseTrueAnswer_Answer_Id",
                        column: x => x.Id,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillBlankAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillBlankAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillBlankAnswer_Answer_Id",
                        column: x => x.Id,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchingAnswer_Answer_Id",
                        column: x => x.Id,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswer_Answer_Id",
                        column: x => x.Id,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AnswersSheetId",
                table: "Answer",
                column: "AnswersSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedBlank_FillBlankAnswer_FillBlankAnswerId",
                table: "SubmittedBlank",
                column: "FillBlankAnswerId",
                principalTable: "FillBlankAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedChoice_MultipleChoiceAnswer_MultipleChoiceAnswerId",
                table: "SubmittedChoice",
                column: "MultipleChoiceAnswerId",
                principalTable: "MultipleChoiceAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedResponse_MatchingAnswer_MatchingAnswerId",
                table: "SubmittedResponse",
                column: "MatchingAnswerId",
                principalTable: "MatchingAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
