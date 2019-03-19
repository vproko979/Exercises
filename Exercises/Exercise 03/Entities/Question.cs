using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Entities
{
    class Question
    {
        public string[] Content { get; set; }
        public string[] Answers { get; set; }

        public Question()
        {
            this.Content = new string[11];
            Content[0] = "Which of the variable types is not a C# variable type?";
            Content[1] = "If we declare an int variable in C# without initialization what default value will it get?";
            Content[2] = "If we declare an var variable in C# without initialization what value will it get?";
            Content[3] = "Which declaration/initialization of the offered is not possible?";
            Content[4] = "How do we initialize a new empty int array";
            Content[5] = "Which of the array declarations is incorrect?";
            Content[6] = "Which of the method signatures is correct?";
            Content[7] = "Can we have more than one method with the same name?";
            Content[8] = "We use classes to instantiate objects in C#, which method does the class use to create our object?";
            Content[9] = "If we don't have a constructor declared in our class, what does the class use to create the new object?";
            Content[10] = "How do we declare a constructor method?";
            this.Answers = new string[11];
            Answers[0] = "a) int\n" +
                         "b) var\n" +
                         "c) let\n" +
                         "d) string";
            Answers[1] = "a) undefined\n" +
                         "b) 0\n" +
                         "c) null\n" +
                         "d) cant declare variable without initialization";
            Answers[2] = "a) undefined\n" +
                         "b) 0\n" +
                         "c) null\n" +
                         "d) cant declare var without initialization";
            Answers[3] = "a) var random = \"Hello World\"\n" +
                         "b) int number = 3\n" +
                         "c) int string = int.Parse(\"4\")\n" +
                         "d) random = number";
            Answers[4] = "a) int[] arr = []\n" +
                         "b) int[] arr = new int[]\n" +
                         "c) int[] arr = new int[] {}\n" +
                         "d) int[] arr = new int[2]";
            Answers[5] = "a) int[] arr = new int[] { 1, 2, 3, 4 }\n" +
                         "b) char[] arr = { 'a', 'b', 'c', 'd' }\n" +
                         "c) var[] arr = new var[] { 1, \"2\", 'c', [1, 2] }\n" +
                         "d) int[][] arr = { new int[] { 1, 2 }, new int[] { 3, 4 } }";
            Answers[6] = "a) public string sayMyName(string name, string lastName)\n" +
                         "b) private sayMyName(string name, string lastName)\n" +
                         "c) public string SayMyName(name, lastName)\n" +
                         "d) public string SayMyName(string name, string lastName)";
            Answers[7] = "a) No, this is not possible in C#\n" +
                         "b) Yes, but the access modifier needs to be different\n" +
                         "c) No, because the name is already used\n" +
                         "d) Yes, but we must declare the new method with different set of parameters";
            Answers[8] = "a) the constructor method\n" +
                         "b) it doesn't use any method\n" +
                         "c) the create new object method\n" +
                         "d) the initialization method";
            Answers[9] = "a) it cannot be done\n" +
                         "b) it will create our object but we cannot set any values to the porperties, ever\n" +
                         "c) the default empty constructor\n" +
                         "d) it orders it from AliExpress";
            Answers[10] = "a) constructor(name, lastName)\n" +
                         "b) new constructor(string name, string lastName)\n" +
                         "c) private ClassName(string name, string lastName)\n" +
                         "d) public ClassName(string name, string lastName)";
        }
    }
}
