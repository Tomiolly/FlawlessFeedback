// <auto-generated />
using System;
using FlawlessFeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlawlessFeedbackAPI.Migrations
{
    [DbContext(typeof(SurveyQuestionContext))]
    [Migration("20211121211147_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Option", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OptionLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("OptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            OptionID = 1,
                            OptionLetter = "A",
                            OptionText = "Yo idk lol",
                            QuestionID = 1
                        },
                        new
                        {
                            OptionID = 2,
                            OptionLetter = "B",
                            OptionText = "Quite possibly large.",
                            QuestionID = 1
                        },
                        new
                        {
                            OptionID = 3,
                            OptionLetter = "A",
                            OptionText = "I think the dog ate it.",
                            QuestionID = 2
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionID = 1,
                            QuestionText = "How long is a piece of string?",
                            SurveyID = 1
                        },
                        new
                        {
                            QuestionID = 2,
                            QuestionText = "Where is my matching sock?",
                            SurveyID = 1
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Survey", b =>
                {
                    b.Property<int>("SurveyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FurtherComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyTopic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyID");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            SurveyID = 1,
                            CreatorName = "Master Chief",
                            DateCreated = new DateTime(2021, 11, 22, 7, 11, 47, 527, DateTimeKind.Local).AddTicks(4578),
                            FurtherComments = "Spartans never die. They're just missing in action.",
                            Logo = "Halo.jpg",
                            SurveyTopic = "Halo Infinite"
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserInfoId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserInfoId = 1,
                            Password = "Password",
                            UserName = "Admin"
                        },
                        new
                        {
                            UserInfoId = 2,
                            Password = "FlawlessFeedback!21",
                            UserName = "Admin@FlawlessFeedback.com"
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Option", b =>
                {
                    b.HasOne("FlawlessFeedbackAPI.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Question", b =>
                {
                    b.HasOne("FlawlessFeedbackAPI.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
