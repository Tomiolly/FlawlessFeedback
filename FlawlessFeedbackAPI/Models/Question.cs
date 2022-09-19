using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int SurveyID { get; set; }

        // Relationships
        public ICollection<Option> Options { get; set; }
        public Survey Survey { get; set; }
    }
}
