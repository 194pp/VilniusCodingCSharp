using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp
{
    public static class MyUtils
    {
        public static void ToggleHighlight()
        {
            Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Red : ConsoleColor.White;
        }
        public static void TaskDisplay(string taskText, string answer)
        {
            ToggleHighlight();
            Console.WriteLine($"Task{taskText}");
            ToggleHighlight();
            if (answer.Length > 0)
                Console.WriteLine(answer);
        }
        public static void TaskDisplay(int taskNr, string answer)
        {
            TaskDisplay(taskNr.ToString(), answer);
        }
        public static string StringArrayJoin(string[] arr)
        {
            return $"[{String.Join(", ", arr)}]";
        }
        public static string StringArrayJoin(List<string> list)
        {
            return StringArrayJoin(list.ToArray());
        }
        public static string StringArrayJoin(List<int> list)
        {
            return StringArrayJoin(list.ToArray().Select(x => x.ToString()).ToArray());
        }
        public static bool IsPrimeNumber(int num)
        {
            //Console.WriteLine($"num {num}");
            if (num < 2) return false;
            bool flag = true;
            for (int i = num - 1; i > 2; i--)
            {
                if (num % i == 0) flag = false;
            }
            return flag;
        }
    }
}
