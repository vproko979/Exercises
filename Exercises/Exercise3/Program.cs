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
            
            Question questions = new Question();
            Answer[] answers = new Answer[11];
            answers[0] = new Answer(false, false, true, false);
            answers[1] = new Answer(false, true, false, false);
            answers[2] = new Answer(false, false, false, true);
            answers[3] = new Answer(false, false, false, true);
            answers[4] = new Answer(false, false, false, true);
            answers[5] = new Answer(false, false, true, false);
            answers[6] = new Answer(false, false, false, true);
            answers[7] = new Answer(false, false, false, true);
            answers[8] = new Answer(true, false, false, false);
            answers[9] = new Answer(false, false, true, false);
            answers[10] = new Answer(false, false, false, true);
            string[] players = new string[0];
            int[] scores = new int[0];

            if (count == 0)
            {
                Console.Write("Please enter your name:");
                playersName = Console.ReadLine();
                Array.Resize(ref players, players.Length + 1);
                players[players.Length - 1] = playersName;
                Console.Clear();
            }

            do
            {
                Console.WriteLine(questions.Content[count]);
                Console.WriteLine(questions.Answers[count]);
                string usersAnswer = Console.ReadLine();

                if (usersAnswer.ToLower() == "a")
                {
                    if (answers[count].A == true)
                    {
                        hits++;
                    }
                }

                if (usersAnswer.ToLower() == "b")
                {
                    if (answers[count].B == true)
                    {
                        hits++;
                    }
                }

                if (usersAnswer.ToLower() == "c")
                {
                    if (answers[count].C == true)
                    {
                        hits++;
                    }
                }

                if (usersAnswer.ToLower() == "d")
                {
                    if (answers[count].D == true)
                    {
                        hits++;
                    }
                }

                Console.Clear();

                count++;

            } while (count < 11);

            Array.Resize(ref scores, scores.Length + 1);
            scores[scores.Length - 1] = hits;


            Console.WriteLine("The number of correct answers is: " + hits);
            Console.WriteLine(ScoringSystem(hits));
            Console.WriteLine("Leader board:");
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null && scores[i] != 0)
                {
                    Console.WriteLine($"Name: {players[i]} ------- Score: {scores[i]}");
                }
                else
                {
                    continue;
                }
            }

            Console.ReadLine();
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
