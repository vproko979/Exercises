using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Entities
{
    class Answer
    {
        public string Content { get; set; }
        public bool Truthfulness { get; set; }

        public Answer(string content, bool truthfulness)
        {
            this.Content = content;
            this.Truthfulness = truthfulness;
        }
    }
}
