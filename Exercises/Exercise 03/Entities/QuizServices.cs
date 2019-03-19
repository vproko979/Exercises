using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Entities
{
    static class QuizServices
    {
        public static string ShowScoreTable(Player[] list)
        {
            string result = "";

            Array.Sort(list, delegate (Player user1, Player user2)
            {
                return user1.Score.CompareTo(user2.Score);
            });
            Array.Reverse(list);

            Console.WriteLine("Leader board:");
            Console.WriteLine();
            foreach (var player in list)
            {
                result += $"{player.PlayerStats()}\n";
            }

            return result;
        }

        public static void ShowTheQuestion(Question[] questions, int count)
        {
            Console.WriteLine(questions[count].Content);
            Console.WriteLine("a)" + questions[count].Answers[0].Content);
            Console.WriteLine("b)" + questions[count].Answers[1].Content);
            Console.WriteLine("c)" + questions[count].Answers[2].Content);
            Console.WriteLine("d)" + questions[count].Answers[3].Content);
        }

        public static bool CheckTheAnswer(string usersAnswer, Question[] questions, int count)
        {
            bool theAnswerIs = false;

            switch (usersAnswer.ToLower())
            {
                case "a":
                    theAnswerIs = questions[count].Answers[0].Truthfulness;
                    break;
                case "b":
                    theAnswerIs = questions[count].Answers[1].Truthfulness;
                    break;
                case "c":
                    theAnswerIs = questions[count].Answers[2].Truthfulness;
                    break;
                case "d":
                    theAnswerIs = questions[count].Answers[3].Truthfulness;
                    break;
            }

            return theAnswerIs;
        }

        public static Answer[] CreateQuestion()
        {

            string[] letters = new string[] { "A", "B", "C", "D" };
            Answer[] answers = new Answer[4];
            bool trueOrFalse = false;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter the answer under " + letters[i] + " :");
                string theAnswer = Console.ReadLine();
                Console.WriteLine("Is this answer correct(y/n)?");
                string isItTrue = Console.ReadLine();
                if (isItTrue == "y")
                {
                    trueOrFalse = true;
                }
                else
                {
                    trueOrFalse = false;
                }
                answers[i] = new Answer(theAnswer, trueOrFalse);
                Console.Clear();
            }

            return answers;
        }

        public static string ScoringSystem(int points)
        {
            string result = "";

            switch (points)
            {
                case int score when (score >= 9):
                    result = "Your score is Excellent. Congratulation.";
                    break;
                case int score when (score < 9 && score >= 5):
                    result = "Your score is very good.";
                    break;
                case int score when (score < 5):
                    result = "Not so good.";
                    break;
            }

            return result;
        }
    }
}
