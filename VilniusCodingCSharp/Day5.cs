using System.Linq;
namespace VilniusCodingCSharp;
public class Day5
{
    public static void Root()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();    // dependencies: Task6
        Task8();    // dependencies: Task6
        Task9();
        Task10();
        Task11();
        Task1Extra();
        Task2Extra();
        Task3Extra();
        Task4Extra();
        Task5Extra();
        Task8Extra();
        Console.WriteLine();
    }
    private static Random rng = new Random();
    private static void Task1()
    {
        static void AddTwoVariablesAndPrint(int num1, int num2)
        {
            int ans = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {ans}");
        }
        MyUtils.TaskDisplay(1, "");
        int num1 = rng.Next(10, 100);
        int num2 = rng.Next(10, 100);
        AddTwoVariablesAndPrint(num1, num2);
    }
    private static void Task2()
    {
        static float PISq()
        {
            return 9.8596f;
        }
        MyUtils.TaskDisplay(2, $"PISq returns: {PISq()}");
    }
    private static void Task3()
    {
        static int MultiplyTwoInts(int num1, int num2)
        {
            return num1 * num2;
        }
        int num1 = rng.Next(10, 100);
        int num2 = rng.Next(10, 100);
        MyUtils.TaskDisplay(3, $"{num1} * {num2} = {MultiplyTwoInts(num1, num2)}");
    }
    private static void Task4()
    {
        static void PrintNumsInRow(int[] nums)
        {
            foreach (int num in nums)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }
        MyUtils.TaskDisplay(4, "");
        int[] ints = new int[10].PopulateWithRandomInts(0, 10);
        PrintNumsInRow(ints);
    }
    private static void Task5()
    {
        static int GenerateRandomInt(int min, int max)
        {
            return rng.Next(min, max);
        }
        int min = 0;
        int max = 0;
        string answer = $"""
            min:        {min}
            max:        {max}
            generated:  {GenerateRandomInt(min, max)}
            """;
        MyUtils.TaskDisplay(5, answer);
    }
    private static int[]? Task6GeneratedInts;
    private static void Task6()
    {
        static int[] GenerateRandomInts(int min, int max, int length)
        {
            return new int[length].PopulateWithRandomInts(min, max);
        }
        int min = 0;
        int max = 10;
        int length = 10;
        Task6GeneratedInts = GenerateRandomInts(min, max, length);
        string answer = $"""
            min:        {min}
            max:        {max}
            length:     {length}
            generated:  {MyUtils.StringArrayJoin(Task6GeneratedInts)}
            """;
        MyUtils.TaskDisplay(6, answer);
    }
    private static int Task7SumIntArray(int[] nums)
    {
        return nums.Sum(x => x);
    }
    private static void Task7()
    {

        int sum = 0;
        if (Task6GeneratedInts != null)
        {
            sum = Task7SumIntArray(Task6GeneratedInts);
        }
        string answer = $"""
            sum: {sum}
            """;
        MyUtils.TaskDisplay(7, answer);
    }
    private static void Task8()
    {
        static double CalculateNumArrayAverage(int[] nums)
        {
            return (double)Task7SumIntArray(nums) / nums.Length;
        }
        double average = 0;
        if (Task6GeneratedInts != null)
        {
            average = CalculateNumArrayAverage(Task6GeneratedInts);
        }
        string answer = $"""
            average: {average}
            """;
        MyUtils.TaskDisplay(8, answer);
    }
    private static void Task9()
    {
        static string GenerateStarSquare(int width, int height)
        {
            string ans = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    ans += "*";
                }
                if (i != height - 1)
                {
                    ans += $"{Environment.NewLine}";
                }
            }
            return ans;
        }
        int height = rng.Next(5, 10);
        int width = rng.Next(10, 20);
        string answer = $"""
            width:  {width}
            height: {height}
            rectangle:
            {GenerateStarSquare(width, height)}
            """;
        MyUtils.TaskDisplay(9, answer);
    }
    private static void Task10()
    {
        static string PrintStringLetterAndGapCount(string str)
        {
            string strTrimmed = str.Trim();
            int gapCount = strTrimmed.Count(Char.IsWhiteSpace);
            int letterCount = strTrimmed.Length - gapCount;
            string ans = $"""
                sentence:       {str}
                gapCount:       {gapCount}
                letterCount:    {letterCount}
                """;
            return ans;
        }
        string sentence = "Šiandien labai graži diena";
        string answer = PrintStringLetterAndGapCount(sentence);
        MyUtils.TaskDisplay(10, answer);
    }
    private static void Task11()
    {
        static string Encode(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = str[str.Length - i - 1];
            }
            return new string(chars);
        }
        string str = "Žilvinas";
        string encoded = Encode(str);
        string answer = $"""
            str:        {str}
            encoded:    {str}
            """;
        MyUtils.TaskDisplay(11, encoded);
    }
    private static void Task1Extra()
    {
        static string WrapStringWithLines(string str)
        {
            return $"---{str}---";
        }
        string str = "Labas";
        string wrappedStr = WrapStringWithLines(str);
        string answer = $"""
            string:         {str}
            wrappedString   {wrappedStr}
            """;
        MyUtils.TaskDisplay("1Extra", answer);
    }
    private static string Task2ExtraGenerateRandomCharStringAndMark(int length)
    {
        int letterMinASCII = 97;
        int letterMaxASCII = 122;
        int numberMinASCII = 48;
        int numberMaxASCII = 57;

        int lettersRange = letterMaxASCII - letterMinASCII;
        int numbersRange = numberMaxASCII - numberMinASCII;
        int wholeRange = lettersRange + numbersRange;

        string ans = "";
        bool isBracketActive = false;
        for (int i = 0; i < length; i++)
        {
            int randomNumber = rng.Next(0, wholeRange + 1);
            bool isNumber = randomNumber < numbersRange;
            if (isNumber)
            {
                if (!isBracketActive)
                {
                    ans += Environment.NewLine + '[';
                    isBracketActive = true;
                }
                char numChar = (char)(randomNumber + numberMinASCII);
                ans += numChar;
            }
            else
            {
                if (isBracketActive)
                {
                    ans += ']' + Environment.NewLine;
                    isBracketActive = false;
                }
                char letterChar = (char)(randomNumber + letterMinASCII - numbersRange);
                ans += letterChar;
            }
        }
        if (isBracketActive)
        {
            ans += ']' + Environment.NewLine;
        }
        return ans;
    }
    private static void Task2Extra()
    {
        int length = 50000;
        string generatedString = Task2ExtraGenerateRandomCharStringAndMark(length);
        string answer = $"""
            length:             {length}
            generatedString:    {generatedString}
            """;
        MyUtils.TaskDisplay("2Extra", answer);
        Console.WriteLine('a');
    }
    private static int[] Task3ExtraFindDivisables(int num)
    {
        if (num < 2) return [];
        List<int> divisables = new List<int>();
        for (int i = 2; i < num; i++)
        {
            if (num % i == 0)
            {
                divisables.Add(i);
            }
        }
        return divisables.ToArray();
    }
    private static void Task3Extra()
    {
        int number = rng.Next(0, 100);
        int[] divisables = Task3ExtraFindDivisables(number);
        int divisiblesCount = divisables.Length;
        string answer = $"""
            number:          {number}
            divisables:      {MyUtils.StringArrayJoin(divisables)}
            divisiblesCount: {divisiblesCount}
            """;
        MyUtils.TaskDisplay("3Extra", answer);
    }
    private static void Task4Extra()
    {
        int length = 100;
        int[] randomNumbers = new int[length].PopulateWithRandomInts(33, 78);
        int[] randomNumbersSorted = [.. randomNumbers];

        randomNumbersSorted = randomNumbersSorted.OrderBy((x) => Task3ExtraFindDivisables(x).Length).ToArray();

        string answer = $"""
            length:              {length}
            randomNumbers:       {MyUtils.StringArrayJoin(randomNumbers)}
            randomNumbersSorted: {MyUtils.StringArrayJoin(randomNumbersSorted)}
            """;
        MyUtils.TaskDisplay("4Extra", answer);
    }
    private static void Task5Extra()
    {
        int length = 100;
        int[] randomNumbers = new int[length].PopulateWithRandomInts(333, 778);
        int[] randomNumbersPrimes = randomNumbers.Where((x) => Task3ExtraFindDivisables(x).Length == 0).ToArray();

        string answer = $"""
            length:                     {length}
            randomNumbers:              {MyUtils.StringArrayJoin(randomNumbers)}
            randomNumbersPrime:         {MyUtils.StringArrayJoin(randomNumbersPrimes)}
            randomNumbersPrimeCount:    {randomNumbersPrimes.Length}
            """;
        MyUtils.TaskDisplay("5Extra", answer);
    }
    private static int[] Task8ExtraGrowArray(int[] nums)
    {
        int[] numsCopy = [.. nums];
        if (nums.Length < 3)
        {
            while (true)
            {
                numsCopy = [.. numsCopy, rng.Next(1, 34)];
                if (numsCopy.Length >= 3) break;
            }
        }
        bool isPrimes = false;
        while (!isPrimes)
        {
            bool num1 = MyUtils.IsPrimeNumber(numsCopy[numsCopy.Length - 3]);
            bool num2 = MyUtils.IsPrimeNumber(numsCopy[numsCopy.Length - 2]);
            bool num3 = MyUtils.IsPrimeNumber(numsCopy[numsCopy.Length - 1]);
            if (num1 && num2 && num3) break;
            numsCopy = [.. numsCopy, rng.Next(1, 34)];
        }
        return numsCopy;
    }
    private static void Task8Extra()
    {
        int[] nums = new int[3].PopulateWithRandomInts(1, 34);
        int[] numsWithLastPrimes = Task8ExtraGrowArray(nums);

        string answer = $"""
            nums:               {MyUtils.StringArrayJoin(nums)}
            numsWithLastPrimes: {MyUtils.StringArrayJoin(numsWithLastPrimes)}
            """;
        MyUtils.TaskDisplay("8Extra", answer);
    }
}
