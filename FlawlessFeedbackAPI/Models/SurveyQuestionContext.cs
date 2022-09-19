using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FlawlessFeedbackAPI.Models
{
    public class SurveyQuestionContext : DbContext
    {
        public SurveyQuestionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        public DbSet<UserInfo> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Survey>().HasData(
                new Survey
                {
                    SurveyID = 1,
                    SurveyTopic = "Halo Infinite",
                    CreatorName = "Master Chief",
                    DateCreated = System.DateTime.Now,
                    FurtherComments = "Spartans never die. They're just missing in action.",
                    Logo = "Halo.jpg"
                }) ;

            builder.Entity<Question>().HasData(
                new Question
                {
                    QuestionID = 1,
                    QuestionText = "How long is a piece of string?",
                    SurveyID = 1,
                });

            builder.Entity<Question>().HasData(
                new Question
                {
                    QuestionID = 2,
                    QuestionText = "Where is my matching sock?",
                    SurveyID = 1,
                });

            builder.Entity<Option>().HasData(
                new Option
                {
                    OptionID = 1,
                    OptionText = "Yo idk lol",
                    OptionLetter = "A",
                    QuestionID = 1
                });

            builder.Entity<Option>().HasData(
                new Option
                {
                    OptionID = 2,
                    OptionText = "Quite possibly large.",
                    OptionLetter = "B",
                    QuestionID = 1
                });
            builder.Entity<Option>().HasData(
                new Option
                {
                    OptionID = 3,
                    OptionText = "I think the dog ate it.",
                    OptionLetter = "A",
                    QuestionID = 2
                });

            builder.Entity<UserInfo>().HasData(
                new UserInfo
                {   
                    UserInfoId = 1,
                    UserName = "Admin",
                    Password = "Password"
                });
            builder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    UserInfoId = 2,
                    UserName = "Admin@FlawlessFeedback.com",
                    Password = "FlawlessFeedback!21"
                });



        }
    }
}
