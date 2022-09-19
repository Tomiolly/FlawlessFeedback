 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string SurveyTopic { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateCreated { get; set; }
        public string FurtherComments { get; set; }
        public string Logo { get; set; }

        // Relationships
        public ICollection<Question> Questions { get; set; }
    }
}
