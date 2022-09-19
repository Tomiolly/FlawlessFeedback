using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Models
{
    public class Option
    {
        public int OptionID { get; set; }
        public string OptionText { get; set; }
        public string OptionLetter { get; set; }
        public int QuestionID { get; set; }
        // Relationships
        public Question Question { get; set; }
    }
}
