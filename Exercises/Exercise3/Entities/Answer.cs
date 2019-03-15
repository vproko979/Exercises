using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Entities
{
    class Answer
    {
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }

        public Answer(bool a, bool b, bool c, bool d)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
        }
    }
}
