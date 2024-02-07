using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp
{
    public class Day3
    {
        public static void Root()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            //Task7();
            //Task8();
            //Task9();
            //Task10();
            //Task1Extra();
            //Task2Extra();
            //Task3Extra();
            //Task4Extra();
            //Task5Extra();
            Task6Extra();
            Task7Extra();
            Task8Extra();
            Task9Extra();
        }
        private static void Task1()
        {
            string answer = "";
            for (int i = 0; i < 10; i++)
            {
                answer += "labas ";
            }
            MyUtils.TaskDisplay(1, answer);
        }
        private static void Task2()
        {
            string answer = "";
            for (int i = 0; i < 10; i++)
                answer += $"{i} ";
            MyUtils.TaskDisplay(2, answer);
        }
        private static string[] plants = ["Pienė",
            "Ramunė",
            "Rožė",
            "Usnis",
            "Ažuolas",
            "Lazdynas",
            "Vyšnia",
            "Beržas",
            "Uosis",
            "Obelis",
            "Drebulė"];
        private static void Task3()
        {
            string answer = "";
            foreach (string plant in plants)
                answer += $"{plant} ";
            MyUtils.TaskDisplay(3, answer);
        }
        private static void Task4()
        {
            string answer = "";
            for (int i = 0; i < plants.Length; i++)
            {
                string newLine = i == plants.Length - 1 ? "" : Environment.NewLine;
                answer += $"{plants[i]}{newLine}";
            }
            MyUtils.TaskDisplay(4, answer);
        }
        private static void Task5()
        {
            string answer = "";
            for (int i = plants.Length - 1; i >= 0; i--)
                answer += $"{plants[i]} ";
            MyUtils.TaskDisplay(5, answer);
        }
        private static void Task6()
        {
            string answer = "";
            for (int i = 10; i <= 50; i += 2)
                answer += $"{i} ";
            MyUtils.TaskDisplay(6, answer);
        }
        private static void Task7()
        {
            string answer = "";
            for (int i = 10; i <= 50; i += 2)
            {
                if (i % 10 == 0) continue;
                answer += $"{i} ";
            }
            MyUtils.TaskDisplay(7, answer);
        }
        private static void Task8()
        {
            int count = 0;
            for (int i = 0; i <= 20; i++)
            {
                if ((i % 2) == 0) count++;
            }
            string answer = $"Even numbers found: {count}";
            MyUtils.TaskDisplay(8, answer);
        }
        private static void Task9()
        {
            int countShort = 0, countLong = 0;
            List<string> wordsShort = new List<string>(), wordsLong = new List<string>();
            foreach (string plant in plants)
            {
                if (plant.Length < 5)
                {
                    countShort++;
                    wordsShort.Add(plant);
                }
                else if (plant.Length > 7)
                {
                    countLong++;
                    wordsLong.Add(plant);
                }
            }
            string wordsShortJoined = wordsShort.Count == 0 ? "" : MyUtils.StringArrayJoin(wordsShort);
            string wordsLongJoined = wordsLong.Count == 0 ? "" : MyUtils.StringArrayJoin(wordsLong);
            string answer = $"""
                shorter than 5 letters count: {countShort} {wordsShortJoined}
                longer than 7 letters count: {countLong} {wordsLongJoined}
                """;
            MyUtils.TaskDisplay(9, answer);
        }
        private static void Task10()
        {
            int count = 0;
            List<string> words = new List<string>();
            foreach (string plant in plants)
            {
                if (plant.Length > 5 && plant.Length < 10)
                {
                    count++;
                    words.Add(plant);
                }
            }
            string wordsJoined = words.Count == 0 ? "" : MyUtils.StringArrayJoin(words);
            string answer = $"""
                longer than 5 letters and shorter than 10 count: {count} {wordsJoined}
                """;
            MyUtils.TaskDisplay(10, answer);
        }
        private static void Task1Extra()
        {
            Random rng = new Random();
            List<string> bigNumbers = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                int number = rng.Next(0, 301);
                if (number > 150 && number <= 275) bigNumbers.Add($"{number}");
                if (number > 275) bigNumbers.Add($"[{number}]");
            }
            string answer = $"""
                numbers: {MyUtils.StringArrayJoin(bigNumbers)}
                """;
            MyUtils.TaskDisplay("1Extra", answer);
        }
        private static void Task2Extra()
        {
            List<string> numbers = new List<string>();
            for (int i = 0; i < 3000; i += 77)
                numbers.Add($"{i}");
            string answer = $"""
                numbers divisible by 77: {MyUtils.StringArrayJoin(numbers)}
                """;
            MyUtils.TaskDisplay("2Extra", answer);
        }
        private static void Task3Extra()
        {
            int size = 25;
            string[,] grid = new string[size, size];
            string answer = $"grid of stars:{Environment.NewLine}";
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                    answer += "*";
                if (i < grid.GetLength(0)) answer += Environment.NewLine;
            }
            MyUtils.TaskDisplay("3Extra", answer);
        }
        private static void Task4Extra()
        {
            MyUtils.TaskDisplay("4Extra", "");
            Console.WriteLine($"grid of stars with color:");
            int size = 25;
            string[,] grid = new string[size, size];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == j || i + j == grid.GetLength(0) - 1) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                    if (i == j || i + j == grid.GetLength(0) - 1) Console.ForegroundColor = ConsoleColor.White;
                }
                if (i < grid.GetLength(0)) Console.WriteLine();
            }
        }
        private static void Task5Extra()
        {
            Random rng = new Random();
            string scenario1 = "Stabdom kai iškrito herbas:                      ";
            string scenario2 = "Stabdom kai iškrito herbas tris kartus:          ";
            string scenario3 = "Stabdom kai iškrito herbas tris kartus iš eilės: ";
            int count2 = 0, count3 = 0;

            MyUtils.TaskDisplay("5Extra", "");
            while (true)
            {
                int randomNum = rng.Next(0, 2);
                scenario1 += randomNum == 0 ? "H" : "S";
                if (randomNum == 0) break;
            }
            Console.WriteLine(scenario1);
            while (count2 < 3)
            {
                int randomNum = rng.Next(0, 2);
                scenario2 += randomNum == 0 ? "H" : "S";
                if (randomNum == 0) count2++;
            }
            Console.WriteLine(scenario2);
            while (count3 < 3)
            {
                int randomNum = rng.Next(0, 2);
                scenario3 += randomNum == 0 ? "H" : "S";
                if (randomNum == 0) count3++;
                else count3 = 0;
            }
            Console.WriteLine(scenario3);
        }
        private static void Task6Extra()
        {
            Random rng = new Random();
            List<int> pScore = new List<int>();
            List<int> kScore = new List<int>();
            int maxScore = 222;
            while (true)
            {
                pScore.Add(rng.Next(10, 21));
                kScore.Add(rng.Next(5, 25));
                if (pScore.Aggregate((x, y) => x + y) >= maxScore && kScore.Aggregate((x, y) => x + y) >= maxScore) break;
            }
            int pTotalScore = pScore.Aggregate((x, y) => x + y);
            int kTotalScore = kScore.Aggregate((x, y) => x + y);
            string winner = "";
            if (pTotalScore > kTotalScore) winner = "Petras";
            else if (kTotalScore > pTotalScore) winner = "Kazys";
            else winner = "It's a draw!";

            int winnerScore = pTotalScore > kTotalScore ? pTotalScore : kTotalScore;

            string answer = $"""
                winner: {winner} ({winnerScore} points)
                Petras points:  {String.Join(" ", pScore.ToArray().Select((x) => x.ToString().PadLeft(2)))}  ({pTotalScore})
                Kazys points:   {String.Join(" ", kScore.ToArray().Select((x) => x.ToString().PadLeft(2)))}  ({kTotalScore})
                """;

            MyUtils.TaskDisplay("6Extra", answer);
        }
        private static void Task7Extra()
        {
            int size = 21;
            string[,] grid = new string[size, size];
            int length = grid.GetLength(0);
            string answer = $"rhombus:";
            for (int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= length; j++)
                {
                    if (i + j > (length + 1) / 2 &&
                        i + j < (length + 1) * 1.5 &&
                        Math.Abs(i - j) < (length + 1) / 2)
                        answer += "*";
                    else answer += " ";
                }
                if (i < grid.GetLength(0)) answer += Environment.NewLine;
            }
            MyUtils.TaskDisplay("7Extra", answer);
        }
        private static void Task8Extra()
        {
            Random rng = new Random();
            string scenario1 = "Using small strikes: ";
            string scenario2 = "Using large strikes: ";

            const int maxNail = 5;
            int nailCount = 0;

            int depth = 0;
            const int maxDepth = 85;

            int hitCount = 0;

            while (nailCount < maxNail)
            {
                hitCount++;
                int deltaDepth = rng.Next(5, 21);
                depth = depth + deltaDepth < maxDepth ? depth + deltaDepth : maxDepth;
                if (depth == maxDepth)
                {
                    depth = 0;
                    nailCount++;
                }
            }
            scenario1 += $"took {hitCount} hits to nail {maxNail} nails.";
            nailCount = 0;

            while (nailCount < maxNail)
            {
                hitCount++;
                bool isSuccess = Convert.ToBoolean(rng.Next(0, 2));
                if (!isSuccess) continue;
                int deltaDepth = rng.Next(20, 31);
                depth = depth + deltaDepth < maxDepth ? depth + deltaDepth : maxDepth;
                if (depth == maxDepth)
                {
                    depth = 0;
                    nailCount++;
                }
            }
            scenario2 += $"took {hitCount} hits to nail {maxNail} nails.";

            string answer = $"""
                {scenario1}
                {scenario2}
                """;
            MyUtils.TaskDisplay("8Extra", answer);
        }
        private static void Task9Extra()
        {
            Random rng = new Random();
            List<int> numbers = new List<int>();
            List<int> primeNumbers = new List<int>();
            int maxListSize = 50;
            while (numbers.Count < maxListSize)
            {
                int randomNum = rng.Next(1, 201);
                if (!numbers.Contains(randomNum)) numbers.Add(randomNum);
            }
            numbers.Sort();
            string ans1 = $"Unique numbers: {MyUtils.StringArrayJoin(numbers)}";
            foreach (int number in numbers)
                if (MyUtils.IsPrimeNumber(number)) primeNumbers.Add(number);
            string ans2 = $"Prime numbers {MyUtils.StringArrayJoin(primeNumbers)}";
            string answer = $"""
                {ans1}
                {ans2}
                """;
            MyUtils.TaskDisplay("9Extra", answer);
        }
    }
}
