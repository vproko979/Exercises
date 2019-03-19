using System;
using Exercise3.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string playersName = "";
            int count = 0;
            int hits = 0;

            Question[] questions = new Question[11];

            Answer firstQuestionA = new Answer("int", false);
            Answer firstQuestionB = new Answer("var", false);
            Answer firstQuestionC = new Answer("let", true);
            Answer firstQuestionD = new Answer("string", false);
            questions[0] = new Question("Which of the variable types is not a C# variable type?", new Answer[] {
                firstQuestionA,
                firstQuestionB,
                firstQuestionC,
                firstQuestionD });

            Answer secondQuestionA = new Answer("undefined", false);
            Answer secondQuestionB = new Answer("0", true);
            Answer secondQuestionC = new Answer("null", false);
            Answer secondQuestionD = new Answer("cant declare variable without initialization", false);
            questions[1] = new Question("If we declare an int variable in C# without initialization what default value will it get?", new Answer[] {
                secondQuestionA,
                secondQuestionB,
                secondQuestionC,
                secondQuestionD });

            Answer thirdQuestionA = new Answer("undefined", false);
            Answer thirdQuestionB = new Answer("0", false);
            Answer thirdQuestionC = new Answer("null", false);
            Answer thirdQuestionD = new Answer("cant declare var without initialization", true);
            questions[2] = new Question("If we declare an var variable in C# without initialization what value will it get?", new Answer[] {
                thirdQuestionA,
                thirdQuestionB,
                thirdQuestionC,
                thirdQuestionD });

            Answer fourthQuestionA = new Answer("var random = \"Hello World\"", false);
            Answer fourthQuestionB = new Answer("int number = 3", false);
            Answer fourthQuestionC = new Answer("int string = int.Parse(\"4\")", false);
            Answer fourthQuestionD = new Answer("random = number", true);
            questions[3] = new Question("Which declaration/initialization of the offered is not possible?", new Answer[] {
                fourthQuestionA,
                fourthQuestionB,
                fourthQuestionC,
                fourthQuestionD });

            Answer fifthQuestionA = new Answer("int[] arr = []", false);
            Answer fifthQuestionB = new Answer("int[] arr = new int[]", false);
            Answer fifthQuestionC = new Answer("int[] arr = new int[] {}", false);
            Answer fifthQuestionD = new Answer("int[] arr = new int[2]", true);
            questions[4] = new Question("How do we initialize a new empty int array", new Answer[] {
                fifthQuestionA,
                fifthQuestionB,
                fifthQuestionC,
                fifthQuestionD });

            Answer sixthQuestionA = new Answer("int[] arr = new int[] { 1, 2, 3, 4 }", false);
            Answer sixthQuestionB = new Answer("char[] arr = { 'a', 'b', 'c', 'd' }", false);
            Answer sixthQuestionC = new Answer("var[] arr = new var[] { 1, \"2\", 'c', [1, 2] }", true);
            Answer sixthQuestionD = new Answer("int[][] arr = { new int[] { 1, 2 }, new int[] { 3, 4 } }", false);
            questions[5] = new Question("Which of the array declarations is incorrect?", new Answer[] {
                sixthQuestionA,
                sixthQuestionB,
                sixthQuestionC,
                sixthQuestionD });

            Answer seventhQuestionA = new Answer("public string sayMyName(string name, string lastName)", false);
            Answer seventhQuestionB = new Answer("private sayMyName(string name, string lastName)", false);
            Answer seventhQuestionC = new Answer("public string SayMyName(name, lastName)", false);
            Answer seventhQuestionD = new Answer("public string SayMyName(string name, string lastName)", true);
            questions[6] = new Question("Which of the method signatures is correct?", new Answer[] {
                seventhQuestionA,
                seventhQuestionB,
                seventhQuestionC,
                seventhQuestionD });

            Answer eigthQuestionA = new Answer("No, this is not possible in C#", false);
            Answer eigthQuestionB = new Answer("Yes, but the access modifier needs to be different", false);
            Answer eigthQuestionC = new Answer("No, because the name is already used", false);
            Answer eigthQuestionD = new Answer("Yes, but we must declare the new method with different set of parameters", true);
            questions[7] = new Question("Can we have more than one method with the same name?", new Answer[] {
                eigthQuestionA,
                eigthQuestionB,
                eigthQuestionC,
                eigthQuestionD });

            Answer ninthQuestionA = new Answer("the constructor method", true);
            Answer ninthQuestionB = new Answer("it doesn't use any method", false);
            Answer ninthQuestionC = new Answer("the create new object method", false);
            Answer ninthQuestionD = new Answer("the initialization method", false);
            questions[8] = new Question("We use classes to instantiate objects in C#, which method does the class use to create our object?", new Answer[] {
                ninthQuestionA,
                ninthQuestionB,
                ninthQuestionC,
                ninthQuestionD});

            Answer tenthQuestionA = new Answer("it cannot be done", false);
            Answer tenthQuestionB = new Answer("it will create our object but we cannot set any values to the properties, ever", false);
            Answer tenthQuestionC = new Answer("the default empty constructor", true);
            Answer tenthQuestionD = new Answer("it orders it from AliExpress", false);
            questions[9] = new Question("If we don't have a constructor declared in our class, what does the class use to create the new object?", new Answer[] {
                tenthQuestionA,
                tenthQuestionB,
                tenthQuestionC,
                tenthQuestionD });

            Answer eleventhQuestionA = new Answer("constructor(name, lastName)", false);
            Answer eleventhQuestionB = new Answer("new constructor(string name, string lastName)", false);
            Answer eleventhQuestionC = new Answer("private ClassName(string name, string lastName)", false);
            Answer eleventhQuestionD = new Answer("public ClassName(string name, string lastName)", true);
            questions[10] = new Question("How do we declare a constructor method?", new Answer[] {
                eleventhQuestionA,
                eleventhQuestionB,
                eleventhQuestionC,
                eleventhQuestionD });

            Player[] players = new Player[] {
                new Player("John", 5),
                new Player("Mike", 9),
                new Player("Bob", 7)
            };          

            do
            {
                Console.WriteLine("Make your choice:");
                Console.WriteLine();
                Console.WriteLine("1) Run the quiz");
                Console.WriteLine("2) Add a question/s");
                Console.WriteLine("3) Check the score board");
                Console.WriteLine("4) Exit the quiz");
                Console.WriteLine();
                Console.Write("Your choice: ");
                string menuSelection = Console.ReadLine();
                Console.Clear();

                if (menuSelection == "1")
                {
                    count = 0;
                    Console.Write("Please enter your name:");
                    playersName = Console.ReadLine();

                    Console.Clear();

                    do
                    {
                        QuizServices.ShowTheQuestion(questions, count);
                        string usersAnswer = Console.ReadLine();

                        if (QuizServices.CheckTheAnswer(usersAnswer, questions, count) == true)
                        {
                            hits++;
                        }

                        Console.Clear();

                        count++;

                    } while (count < questions.Length);

                    Array.Resize(ref players, players.Length + 1);
                    players[players.Length - 1] = new Player(playersName, hits);

                    Array.Sort(players, delegate (Player user1, Player user2)
                    {
                        return user1.Score.CompareTo(user2.Score);
                    });

                    Console.WriteLine("The number of correct answers is: " + hits);
                    Console.WriteLine(QuizServices.ScoringSystem(hits));
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(QuizServices.ShowScoreTable(players));
                    hits = 0;
                }
                else if (menuSelection == "2")
                {
                    do
                    {
                        Console.WriteLine("1) Enter a question");
                        Console.WriteLine("2) Back to main menu");
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        string selection = Console.ReadLine();
                        Console.Clear();

                        if (selection == "1")
                        {
                            Console.WriteLine("Enter the content of the question:");
                            string questionsContent = Console.ReadLine();

                            Answer[] theAnswers = QuizServices.CreateQuestion();

                            Question usersQuestion = new Question(questionsContent, theAnswers);
                            Array.Resize(ref questions, questions.Length + 1);
                            questions[questions.Length - 1] = usersQuestion;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);

                }
                else if (menuSelection == "3")
                {
                    do
                    {
                        Console.WriteLine(QuizServices.ShowScoreTable(players));
                        Console.WriteLine();
                        Console.WriteLine("1) Back to main menu");
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        string userSelect = Console.ReadLine();
                        Console.Clear();

                        if (userSelect == "1")
                        {
                            break;
                        }
                    } while (true);

                }
                else
                {
                    break;
                }
            } while (true);

            Console.ReadLine();
        }
    }
}
