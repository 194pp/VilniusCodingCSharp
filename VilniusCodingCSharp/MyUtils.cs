using System.Text;
namespace VilniusCodingCSharp;
public static class MyUtils
{
    public static void ToggleHighlight()
    {
        Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Red : ConsoleColor.White;
    }
    public static void ToggleHighlight(bool isRed)
    {
        Console.ForegroundColor = isRed ? ConsoleColor.Red : ConsoleColor.White;
    }
    public static void TaskDisplay(string taskText, string answer)
    {
        ToggleHighlight(true);
        Console.WriteLine($"Task{taskText}");
        ToggleHighlight(false);
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
    public static string StringArrayJoin(int[] arr)
    {
        return StringArrayJoin(arr.Select(x => x.ToString()).ToArray());
    }
    public static string StringArrayJoin(List<string> list)
    {
        return StringArrayJoin(list.ToArray());
    }
    public static string StringArrayJoin(List<int> list)
    {
        return StringArrayJoin(list.Select(x => x.ToString()).ToArray());
    }
    public static bool IsPrimeNumber(int num)
    {
        if (num < 2) return false;
        bool flag = true;
        for (int i = num - 1; i > 2; i--)
        {
            if (num % i == 0) flag = false;
        }
        return flag;
    }
    public static T[] Populate<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++) arr[i] = value;
        return arr;
    }
    public static int[] PopulateWithRandomInts(this int[] arr, int start, int end)
    {
        Random r = new Random();
        for (int i = 0; i < arr.Length; i++) arr[i] = r.Next(start, end);
        return arr;
    }
    public static string StringJagged2DArrayJoin(int[][] arr)
    {
        StringBuilder sb = new("[");
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append($"[{String.Join(", ", arr[i])}],");
        }
        sb[sb.Length - 1] = ']';
        return sb.ToString();
    }
    public static string StringJagged2DArrayJoin(string[][] arr)
    {
        StringBuilder sb = new("[");
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append($"[{String.Join(", ", arr[i])}],");
        }
        sb[sb.Length - 1] = ']';
        return sb.ToString();
    }
}