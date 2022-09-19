using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyTopic = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FurtherComments = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(nullable: true),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(nullable: true),
                    OptionLetter = table.Column<string>(nullable: true),
                    QuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionID);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyID", "CreatorName", "DateCreated", "FurtherComments", "Logo", "SurveyTopic" },
                values: new object[] { 1, "Master Chief", new DateTime(2021, 11, 22, 7, 11, 47, 527, DateTimeKind.Local).AddTicks(4578), "Spartans never die. They're just missing in action.", "Halo.jpg", "Halo Infinite" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoId", "Password", "UserName" },
                values: new object[] { 1, "Password", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoId", "Password", "UserName" },
                values: new object[] { 2, "FlawlessFeedback!21", "Admin@FlawlessFeedback.com" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "QuestionText", "SurveyID" },
                values: new object[] { 1, "How long is a piece of string?", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "QuestionText", "SurveyID" },
                values: new object[] { 2, "Where is my matching sock?", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionID", "OptionLetter", "OptionText", "QuestionID" },
                values: new object[] { 1, "A", "Yo idk lol", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionID", "OptionLetter", "OptionText", "QuestionID" },
                values: new object[] { 2, "B", "Quite possibly large.", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionID", "OptionLetter", "OptionText", "QuestionID" },
                values: new object[] { 3, "A", "I think the dog ate it.", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionID",
                table: "Options",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyID",
                table: "Questions",
                column: "SurveyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
