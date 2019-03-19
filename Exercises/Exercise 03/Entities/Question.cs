using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Entities
{
    class Question
    {
        public string Content { get; set; }
        public Answer[] Answers { get; set; }

        public Question(string content, Answer[] answers)
        {
            Content = content;
            Answers = answers;
        }
    }
}
