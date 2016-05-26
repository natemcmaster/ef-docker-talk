using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contoso.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResponse_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ExamId = table.Column<int>(nullable: false),
                    Points = table.Column<double>(nullable: false),
                    Prompt = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CorrectAnswerId = table.Column<int>(nullable: true),
                    ExpectedAnswer = table.Column<string>(nullable: true),
                    IsCaseSensitive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    AnswerText = table.Column<string>(nullable: true),
                    MultipleChoiceQuestionId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceOption_Question_MultipleChoiceQuestionId",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ExamResponseId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SelectedOptionId = table.Column<int>(nullable: true),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_MultipleChoiceOption_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "MultipleChoiceOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_ExamResponse_ExamResponseId",
                        column: x => x.ExamResponseId,
                        principalTable: "ExamResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResponse_ExamId",
                table: "ExamResponse",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceOption_MultipleChoiceQuestionId",
                table: "MultipleChoiceOption",
                column: "MultipleChoiceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceOption_QuestionId",
                table: "MultipleChoiceOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamId",
                table: "Question",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CorrectAnswerId",
                table: "Question",
                column: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_ExamResponseId",
                table: "QuestionResponse",
                column: "ExamResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_QuestionId",
                table: "QuestionResponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_SelectedOptionId",
                table: "QuestionResponse",
                column: "SelectedOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_MultipleChoiceOption_CorrectAnswerId",
                table: "Question",
                column: "CorrectAnswerId",
                principalTable: "MultipleChoiceOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Exam_ExamId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceOption_Question_MultipleChoiceQuestionId",
                table: "MultipleChoiceOption");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceOption_Question_QuestionId",
                table: "MultipleChoiceOption");

            migrationBuilder.DropTable(
                name: "QuestionResponse");

            migrationBuilder.DropTable(
                name: "ExamResponse");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "MultipleChoiceOption");
        }
    }
}
