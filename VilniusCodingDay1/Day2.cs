using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VilniusCodingCSharp
{
    public class Day2
    {
        public static void Root()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();
        }
        public static void ToggleHighlight()
        {
            Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Red : ConsoleColor.White;
        }
        public static void TaskDisplay(int taskNr, string answer)
        {
            ToggleHighlight();
            Console.WriteLine($"Task{taskNr}");
            ToggleHighlight();
            Console.WriteLine(answer);
        }
        public static void Task1()
        {
            string firstName = "Jonas";
            string lastName = "Jonaitis";

            string shorterString;

            if (firstName.Length == lastName.Length)
            {
                shorterString = "Both are equal";
            }
            else if (firstName.Length > lastName.Length)
            {
                shorterString = lastName;
            }
            else
            {
                shorterString = firstName;
            }

            string answer = $"""
                firstName:      {firstName} ({firstName.Length} characters long)
                lastName:       {lastName} ({lastName.Length} characters long)
                shorter:        {shorterString}
                """;

            TaskDisplay(1, answer);
        }
        public static void Task2()
        {
            string firstName = "Leonardo";
            string lastName = "Dicaprio";

            string answer = $"""
                firstName:      {firstName.ToUpper()}
                lastName:       {lastName.ToLower()}
                """;

            TaskDisplay(2, answer);
        }
        public static void Task3()
        {
            string firstName = "Leonardo";
            string lastName = "Dicaprio";
            string acronym = $"{firstName[0]}{lastName[0]}";

            string answer = $"""
                firstName:      {firstName}
                lastName:       {lastName}
                acronym:        {acronym}
                """;

            TaskDisplay(3, answer);
        }
        public static void Task4()
        {
            string firstName = "Leonardo";
            string lastName = "Dicaprio";
            string combinedEnds = $"{firstName.Substring(firstName.Length - 3)}{lastName.Substring(lastName.Length - 3)}";

            string answer = $"""
                firstName:      {firstName}
                lastName:       {lastName}
                combinedEnds:   {combinedEnds}
                """;

            TaskDisplay(4, answer);
        }
        public static void Task5()
        {
            string startingString = "An American in Paris";
            string censoredString = startingString.Replace('a', '*').Replace('A', '*');

            string answer = $"""
                startingString: {startingString}
                censoredString: {censoredString}
                """;

            TaskDisplay(5, answer);
        }
        public static void Task6()
        {
            string vowels = "AaĄąEeĘęĖėIiĮįYyOoUuŲųŪū";
            string str1 = "An American in Paris";
            string str2 = "Breakfast at Tiffany's";
            string str3 = "2001: A Space Odyssey";
            string str4 = "It's a Wonderful Life";

            string str1new = new string(str1.Where((c) => !vowels.Contains(c)).ToArray());
            string str2new = new string(str2.Where((c) => !vowels.Contains(c)).ToArray());
            string str3new = new string(str3.Where((c) => !vowels.Contains(c)).ToArray());
            string str4new = new string(str4.Where((c) => !vowels.Contains(c)).ToArray());

            string answer = $"""
                startingStrings:        [{str1}, {str2}, {str3}, {str4}]
                vowel-less-Strings:     [{str1new}, {str2new}, {str3new}, {str4new}]
                """;
            TaskDisplay(6, answer);
        }
        public static void Task7()
        {
            string episode = $"Star Wars: Episode {string.Join("", Enumerable.Repeat(' ', new Random().Next(10)))} {(new Random().Next(7) + 1)} - A New Hope";
            string numberRegex = @"[0-9]";
            string num = Regex.Match(episode, numberRegex).Value;

            string answer = $"""
                episode:        {episode}
                episodeNumber:  {num}
                """;
            TaskDisplay(7, answer);
        }
        public static void Task8()
        {
            string initialString = "Don't Be a Menace to South Central While Drinking Your Juice in the Hood";
            string initialStringLt = "Tik nereikia gąsdinti Pietų Centro, geriant sultis pas save kvartale";

            string[] initialStringWords = initialString.Split(' ');
            string[] initialStringLtWords = initialString.Split(' ');
            int count1 = 0;
            int count2 = 0;

            foreach (string word in initialStringWords)
            {
                if (word.Length < 6) count1++;
            }
            foreach (string word in initialStringLtWords)
            {
                if (word.Length < 6) count2++;
            }

            string answer = $"""
                initialString:                  {initialString} 
                words with 5 or less letters:   {count1}
                initialStringLt:                {initialStringLt} 
                words with 5 or less letters:   {count2}
                """;
            TaskDisplay(8, answer);
        }
        public static void Task9()
        {
            Random rng = new Random();
            int len = 3;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string rngString = new string(Enumerable.Repeat(chars, len)
                .Select(s => s[rng.Next(s.Length)]).ToArray()).ToLower();

            string answer = $"""
                len:        {len}
                rngString:  {rngString}
                """;
            TaskDisplay(9, answer);
        }
        public static void Task10()
        {
            Random rng = new Random();
            string initialString = "Don't Be a Menace to South Central While Drinking Your Juice in the Hood";
            string initialStringLt = "Tik nereikia gąsdinti Pietų Centro, geriant sultis pas save kvartale";
            string jointString = $"{initialString} {initialStringLt}";
            int len = 10;

            string ans = "";

            for (int i = 0; i < len; i++)
            {
                List<string> tempArr = jointString.Split(' ').ToList();
                int index = rng.Next(0, tempArr.Count - 1);
                string item = tempArr[index];
                ans += $"{item} ";
                tempArr.RemoveAt(index);
                jointString = tempArr.Aggregate((a, b) => a + ' ' + b);
            }

            string answer = $"""
                random text: {ans}
                """;
            TaskDisplay(10, answer);
        }
    }
}
