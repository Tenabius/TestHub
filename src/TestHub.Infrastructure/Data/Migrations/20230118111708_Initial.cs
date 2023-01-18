using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassingPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AttemptAllowed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    StartTestingTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndTestingTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestForms_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestForms_Users_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FalseTrueQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CorrectChoice = table.Column<bool>(type: "bit", nullable: false),
                    Statment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FalseTrueQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FalseTrueQuestion_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillBlankQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillBlankQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillBlankQuestion_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchingQuestion_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Stem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMultipleAnswers = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestion_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TestFormId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionForm_TestForms_TestFormId",
                        column: x => x.TestFormId,
                        principalTable: "TestForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FillBlankQuestionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blank_FillBlankQuestion_FillBlankQuestionId",
                        column: x => x.FillBlankQuestionId,
                        principalTable: "FillBlankQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchingQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Response_MatchingQuestion_MatchingQuestionId",
                        column: x => x.MatchingQuestionId,
                        principalTable: "MatchingQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_MultipleChoiceQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "MultipleChoiceQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FalseTrueQuestionForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SelectedChoice = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FalseTrueQuestionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FalseTrueQuestionForm_QuestionForm_Id",
                        column: x => x.Id,
                        principalTable: "QuestionForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillBlankQuestionForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubmittedAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillBlankQuestionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillBlankQuestionForm_QuestionForm_Id",
                        column: x => x.Id,
                        principalTable: "QuestionForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingQuestionFrom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubmittedAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingQuestionFrom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchingQuestionFrom_QuestionForm_Id",
                        column: x => x.Id,
                        principalTable: "QuestionForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestionForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SelectedChoicesId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestionForm_QuestionForm_Id",
                        column: x => x.Id,
                        principalTable: "QuestionForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectResponseId = table.Column<int>(type: "int", nullable: false),
                    MatchingQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stem_MatchingQuestion_MatchingQuestionId",
                        column: x => x.MatchingQuestionId,
                        principalTable: "MatchingQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stem_Response_CorrectResponseId",
                        column: x => x.CorrectResponseId,
                        principalTable: "Response",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blank_FillBlankQuestionId",
                table: "Blank",
                column: "FillBlankQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionId",
                table: "Choice",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionForm_TestFormId",
                table: "QuestionForm",
                column: "TestFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_MatchingQuestionId",
                table: "Response",
                column: "MatchingQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Stem_CorrectResponseId",
                table: "Stem",
                column: "CorrectResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stem_MatchingQuestionId",
                table: "Stem",
                column: "MatchingQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestForms_CandidateId",
                table: "TestForms",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_TestForms_TestId",
                table: "TestForms",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AuthorId",
                table: "Tests",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blank");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "FalseTrueQuestion");

            migrationBuilder.DropTable(
                name: "FalseTrueQuestionForm");

            migrationBuilder.DropTable(
                name: "FillBlankQuestionForm");

            migrationBuilder.DropTable(
                name: "MatchingQuestionFrom");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestionForm");

            migrationBuilder.DropTable(
                name: "Stem");

            migrationBuilder.DropTable(
                name: "FillBlankQuestion");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestion");

            migrationBuilder.DropTable(
                name: "QuestionForm");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "TestForms");

            migrationBuilder.DropTable(
                name: "MatchingQuestion");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
