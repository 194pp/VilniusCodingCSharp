﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingCSharp;
public class Day4
{
    public static void Root()
    {
        Console.ForegroundColor = ConsoleColor.White;
        //Task1();
        //Task2(); // Dependency: Task1
        //Task3();
        //Task4();
        //Task5();
        //Task6();
        //Task7(); // Dependency: Task6
        //Task8();
        //Task9();
        //Task10();
        Task1Php();
        Task2Php();
        Task3Php();
        Task4Php();
        Task5Php();
        Task6Php(); // Dependency: Task5Php
        Task7Php(); // Dependency: Task5Php
        Task8Php();
    }
    private static Random rng = new Random();
    private static int[] numsForTask1 = new int[30];
    private static int limLowTask1 = 5;
    private static int limHighTask1 = 26;
    private static void Task1()
    {
        Random rng = new Random();
        for (int i = 0; i < numsForTask1.Length - 1; i++)
            numsForTask1[i] = rng.Next(limLowTask1, limHighTask1);
        string answer = $"""
                Array: {MyUtils.StringArrayJoin(numsForTask1)}
                """;
        MyUtils.TaskDisplay(1, answer);
    }
    private static void Task2()
    {
        Random rng = new Random();
        int countOver10 = 0;
        List<int[]> largestNumbers = new List<int[]>(); // [index, value]
        int evenIndicesSum = 0;
        int[] newArrOfNums = new int[numsForTask1.Length];
        int[] newArrOfNumsExpanded = new int[numsForTask1.Length + 10];

        string scenarioA = "a) ";
        string scenarioB = "b) ";
        string scenarioC = "c) ";
        string scenarioD = "d) ";
        string scenarioE = "e) ";
        string scenarioF = "f) ";
        string scenarioG = "g) ";
        string scenarioH = "h) ";

        for (int i = 0; i < numsForTask1.Length; i++)
        {
            // a
            if (numsForTask1[i] > 10) countOver10++;


            // b               
            if (largestNumbers.Count == 0 || largestNumbers.ElementAt(0)[1] < numsForTask1[i])
            {
                largestNumbers.Clear();
                largestNumbers.Add([i, numsForTask1[i]]);
            }
            else if (largestNumbers.ElementAt(0)[1] == numsForTask1[i])
                largestNumbers.Add([i, numsForTask1[i]]);

            // c
            if (numsForTask1[i] % 2 == 0) evenIndicesSum += i;

            // d
            newArrOfNums[i] = numsForTask1[i] - i;

            // e part 1
            newArrOfNumsExpanded[i] = numsForTask1[i];
        }
        scenarioA += $"{countOver10}.";
        scenarioB += $"{MyUtils.StringArrayJoin(largestNumbers.Select(x => MyUtils.StringArrayJoin(x)).ToArray())}.   [index, value]";
        scenarioC += $"{evenIndicesSum}.";
        scenarioD += $"{MyUtils.StringArrayJoin(newArrOfNums)}";
        // e part 2
        for (int i = numsForTask1.Length; i < newArrOfNumsExpanded.Length; i++)
            newArrOfNumsExpanded[i] = rng.Next(limLowTask1, limHighTask1);
        numsForTask1 = [.. newArrOfNumsExpanded];
        scenarioE += $"{MyUtils.StringArrayJoin(numsForTask1)}.";
        List<int> evenNums = new List<int>();
        List<int> oddNums = new List<int>();
        for (int i = 0; i < numsForTask1.Length; i++)
        {
            // f + g
            if (numsForTask1[i] % 2 == 0)
                evenNums.Add(numsForTask1[i]);
            else oddNums.Add(numsForTask1[i]);
        }
        scenarioF += $"""

                EvenNums: {MyUtils.StringArrayJoin(evenNums)}
                OddNums:  {MyUtils.StringArrayJoin(oddNums)}
                """;
        for (int i = 0; i < evenNums.Count; i++)
            evenNums[i] = evenNums[i] > 15 ? 0 : evenNums[i];
        scenarioG += $"""

                EvenNums: {MyUtils.StringArrayJoin(evenNums)}
                """;
        string smallestTenIndex = "No number is higher than 10.";
        for (int i = 0; i < numsForTask1.Length; i++)
        {
            if (numsForTask1[i] > 10)
            {
                smallestTenIndex = $"index: {i} (value: {numsForTask1[i]}).";
                break;
            }
        }
        scenarioH += $"{smallestTenIndex}";
        string answer = $"""
                {scenarioA}
                {scenarioB}
                {scenarioC}
                {scenarioD}
                {scenarioE}
                {scenarioF}
                {scenarioG}
                {scenarioH}
                """;
        MyUtils.TaskDisplay(2, answer);
    }
    private static string task3String = "";
    private const string letters = "ABCD";
    private static void Task3()
    {
        const int len = 200;
        int[] letterCounts = new int[letters.Length];
        for (int i = 0; i < len; i++)
        {
            int rngNum = rng.Next(0, letters.Length);
            task3String += letters[rngNum];
            letterCounts[rngNum]++;
        }
        Console.WriteLine(MyUtils.StringArrayJoin(letterCounts));
        string answer = $"""
                Text: {task3String}
                Letter counts: 
                {MyUtils.StringArrayJoin(letterCounts)} 
                {MyUtils.StringArrayJoin(letters.Select(x => $"{x}").ToArray())}
                """;
        MyUtils.TaskDisplay(3, answer);
    }
    private static void Task4()
    {
        string sortedString = String.Join("", task3String.Select(x => $"{x}").ToArray().OrderBy(x => x));
        string answer = $"""
                sortedString: {sortedString}
                """;
        MyUtils.TaskDisplay(4, answer);
    }
    private static void Task5()
    {
        int len = 200;
        string[] arr1 = new string[len];
        string[] arr2 = new string[len];
        string[] arr3 = new string[len];
        HashSet<string> stringSet = new HashSet<string>();
        List<string> uniqueValues = new List<string>();

        for (int i = 0; i < len; i++)
        {
            arr1[i] = $"{letters[rng.Next(0, letters.Length)]}";
            arr2[i] = $"{letters[rng.Next(0, letters.Length)]}";
            arr3[i] = $"{letters[rng.Next(0, letters.Length)]}";
        }

        for (int i = 0; i < len; i++)
        {
            string element = $"{arr1[i]}{arr2[i]}{arr3[i]}";
            stringSet.Add(element);
            if (uniqueValues.Contains(element))
            {
                uniqueValues.RemoveAll(x => x == element);
            }
            else
            {
                uniqueValues.Add(element);
            }
        }
        int uniqueSets = stringSet.Count();

        string answer = $"""
                UniqueSetsAmount:   {uniqueSets}
                UniqueSets:         {MyUtils.StringArrayJoin(stringSet.OrderBy(x => x).ToArray())}
                UniqueValuesAmount: {uniqueValues.Count}
                UniqueValues:       {MyUtils.StringArrayJoin(uniqueValues)}
                """;
        MyUtils.TaskDisplay(5, answer);
    }
    private static int[] task6Arr1 = new int[100];
    private static int[] task6Arr2 = new int[100];
    private static void Task6()
    {
        int len = task6Arr1.Length;
        int[] lim = [100, 1000];

        for (int i = 0; i < len; i++)
        {
            while (true)
            {
                int randomNum = rng.Next(lim[0], lim[1]);
                if (!task6Arr1.Contains(randomNum))
                {
                    task6Arr1[i] = randomNum;
                    break;
                }
            }
            while (true)
            {
                int randomNum = rng.Next(lim[0], lim[1]);
                if (!task6Arr2.Contains(randomNum))
                {
                    task6Arr2[i] = randomNum;
                    break;
                }
            }
        }
        string answer = $"""
                arr1: 
                {MyUtils.StringArrayJoin(task6Arr1.OrderBy(x => x).ToArray())}
                arr2: 
                {MyUtils.StringArrayJoin(task6Arr2.OrderBy(x => x).ToArray())}
                """;
        MyUtils.TaskDisplay(6, answer);
    }
    private static void Task7()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < task6Arr1.Length; i++)
        {
            if (!task6Arr2.Contains(task6Arr1[i]))
            {
                list.Add(task6Arr1[i]);
            }
        }
        string answer = $"""
                diff array from Task6:  
                {MyUtils.StringArrayJoin(list.OrderBy(x => x).ToArray())}
                """;
        MyUtils.TaskDisplay(7, answer);
    }
    private static void Task8()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < task6Arr1.Length; i++)
        {
            if (task6Arr2.Contains(task6Arr1[i]))
            {
                list.Add(task6Arr1[i]);
            }
        }
        string answer = $"""
                match array from Task6: 
                {MyUtils.StringArrayJoin(list.OrderBy(x => x).ToArray())}
                """;
        MyUtils.TaskDisplay(8, answer);
    }
    private static void Task9()
    {
        int[] arr = new int[10];
        arr[0] = rng.Next(5, 26);
        arr[1] = rng.Next(5, 26);

        for (int i = 2; i < arr.Length; i++)
        {
            arr[i] = arr[i - 2] + arr[i - 1];
        }

        string answer = $"""
                FibArray: {MyUtils.StringArrayJoin(arr)} 
                """;
        MyUtils.TaskDisplay(9, answer);
    }
    private static void Task10()
    {
        int len = 101;
        int[] arr = new int[len];
        int[] arrCentered = new int[len];
        int[] lim = [0, 300];


        for (int i = 0; i < len; i++)
        {
            while (true)
            {
                int randomNum = rng.Next(lim[0], lim[1]);
                if (!arr.Contains(randomNum))
                {
                    arr[i] = randomNum;
                    break;
                }
            }
        }
        string originalArray = $"OriginalArray: {MyUtils.StringArrayJoin(arr)}";
        arr = arr.OrderByDescending(x => x).ToArray();

        for (int i = 0; i < arrCentered.Length; i++)
        {
            int midway = arr.Length / 2;
            int delta = (i + 1) / 2;
            int inverter = (int)Math.Pow(-1, i);
            int index = midway + (delta * inverter);

            arrCentered[index] = arr[i];
        }
        string centeredArray = $"CenteredArray: {MyUtils.StringArrayJoin(arrCentered)}";

        string answer = $"""
                {originalArray}
                {centeredArray}
                """;
        MyUtils.TaskDisplay(10, answer);
    }
    private static List<List<int>> twoDimensionalList = new List<List<int>>();
    private static string twoDimArrString = "";
    private static void Task1Php()
    {
        int dim1 = 10;
        int dim2 = 5;
        for (int i = 0; i < dim1; i++)
        {
            twoDimensionalList.Add(new List<int>());
            twoDimArrString += "[";
            for (int j = 0; j < dim2; j++)
            {
                int num = rng.Next(5, 26);
                twoDimensionalList[i].Add(num);
                twoDimArrString += $"{num},";
            }
            twoDimArrString = twoDimArrString.Trim(',');
            twoDimArrString += "],";
        }
        twoDimArrString = $"[{twoDimArrString.Trim(',')}]";

        string answer = $"""
                twoDimensionalArray:
                {twoDimArrString}
                """;
        MyUtils.TaskDisplay("1Php", answer);
    }
    private static void Task2Php()
    {
        int countA = 0;
        int numMax = 0;
        int[] firstDimensionSums = new int[twoDimensionalList[0].Count];

        for (int i = 0; i < twoDimensionalList.Count; i++)
        {
            for (int j = 0; j < twoDimensionalList[i].Count; j++)
            {
                firstDimensionSums[j] += twoDimensionalList[i][j];
                if (twoDimensionalList[i][j] > 10)
                {
                    countA++;
                }
                if (numMax < twoDimensionalList[i][j])
                {
                    numMax = twoDimensionalList[i][j];
                }
            }
        }
        string extended2DListDisplay = "[";
        string extended2DListRowSumsDisplay = "[";
        for (int i = 0; i < twoDimensionalList.Count; i++)
        {
            int[] tempArr = new int[7];
            for (int j = 0; j < tempArr.Length; j++)
            {
                if (j < twoDimensionalList[i].Count)
                {
                    tempArr[j] = twoDimensionalList[i][j];
                }
                else
                {
                    tempArr[j] = rng.Next(5, 26);
                }
            }
            extended2DListDisplay += $"{MyUtils.StringArrayJoin(tempArr)},";
            extended2DListRowSumsDisplay += $"{tempArr.Aggregate((acc, curr) => acc + curr)},";
        }
        extended2DListDisplay = extended2DListDisplay.Trim(',');
        extended2DListDisplay += "]";
        extended2DListRowSumsDisplay = extended2DListRowSumsDisplay.Trim(',');
        extended2DListRowSumsDisplay += "]";
        string answer = $"""
                a) {countA}.
                b) {numMax}.
                c) {MyUtils.StringArrayJoin(firstDimensionSums)}.
                d) {extended2DListDisplay}.
                e) {extended2DListRowSumsDisplay}.
                """;
        MyUtils.TaskDisplay("2Php", answer);
    }
    private static string[] Task3PhpGenerateRandomLetterArray(int length)
    {
        if (length < 1) return [];
        int min = 65;
        int max = 90;
        string[] charArr = new string[length];
        for (int i = 0; i < length; i++)
        {
            charArr[i] = $"{(char)rng.Next(min, max + 1)}";
        }
        return charArr;
    }
    private static string[][] Task3PhpSortLetterStrings(string[][] arr)
    {
        string[][] arrCopy = [.. arr];
        for (int i = 0; i < arr.Length; i++)
        {
            arrCopy[i] = [.. arrCopy[i].OrderBy((x) => x)];
        }
        return arrCopy;
    }
    private static string[][] jaggedArr = new string[10][];
    private static void Task3Php()
    {
        for (int i = 0; i < jaggedArr.Length; i++)
        {
            jaggedArr[i] = Task3PhpGenerateRandomLetterArray(rng.Next(2, 21));
        }
        string jaggedArrBeforeSort = MyUtils.StringJagged2DArrayJoin(jaggedArr);
        string[][] jaggedSortedArr = Task3PhpSortLetterStrings(jaggedArr);
        string jaggedArrAfterSort = MyUtils.StringJagged2DArrayJoin(jaggedSortedArr);
        string answer = $"""
            jaggedArrBeforeSort: {jaggedArrBeforeSort}
            jaggedArrAfterSort:  {jaggedArrAfterSort}
            """;
        MyUtils.TaskDisplay("3Php", answer);
    }
    private static void Task4Php()
    {
        jaggedArr = jaggedArr.OrderBy(x => x.Length).ToArray();
        string answer = $"""
            sortedRootArray: {MyUtils.StringJagged2DArrayJoin(jaggedArr)}
            """;
        MyUtils.TaskDisplay("4Php", answer);
    }
    private static (int user_id, int place_in_row)[] tupleArr = new (int, int)[30];
    private static string Task5PhpPrintTupleArr((int user_id, int place_in_row)[] tupleArr)
    {
        string ans = "[";
        for (int i = 0; i < tupleArr.Length; i++)
        {
            ans += "{";
            ans += $"user_id: {tupleArr[i].user_id}, place_in_row: {tupleArr[i].place_in_row}";
            ans += "}";
            if (i == tupleArr.Length - 1) ans += "]";
            else ans += $",{Environment.NewLine}";
        }
        return ans;
    }
    private static (int user_id, int place_in_row)[] Task5PhpMapTupleForTask((int user_id, int place_in_row)[] tupleArr)
    {
        (int user_id, int place_in_row)[] arr = [.. tupleArr];
        for (int i = 0; i < arr.Length; i++)
        {
            while (true)
            {
                int userId = rng.Next(1, 1000001);
                if (arr.Length > 0 && arr.Where(x => x.user_id == userId).ToArray().Length > 0) continue;
                int placeInRow = rng.Next(0, 101);
                arr[i] = (userId, placeInRow);
                break;
            }
        }
        return arr;
    }
    private static void Task5Php()
    {
        tupleArr = Task5PhpMapTupleForTask(tupleArr);
        string ans = Task5PhpPrintTupleArr(tupleArr);
        string answer = $"""
            tupleArray:
            {ans}
            """;
        MyUtils.TaskDisplay("5Php", answer);
    }
    private static void Task6Php()
    {
        string stringTupleArrSortedByUserId = Task5PhpPrintTupleArr([.. tupleArr.OrderBy((x) => x.user_id)]);
        string stringTupleArrSortedByPlaceInRow = Task5PhpPrintTupleArr([.. tupleArr.OrderBy((x) => x.place_in_row)]);

        string answer = $"""
            sortedByUserId:
            {stringTupleArrSortedByUserId}
            sortedByPlaceInRow:
            {stringTupleArrSortedByPlaceInRow}
            """;
        MyUtils.TaskDisplay("6Php", answer);
    }
    private static string Task7PhpPrintBetterTupleArr((int user_id, int place_in_row, string name, string surname)[] betterTupleArr)
    {
        string ans = "[";
        for (int i = 0; i < tupleArr.Length; i++)
        {
            ans += "{";
            ans += $"user_id: {betterTupleArr[i].user_id}, " +
                $"place_in_row: {betterTupleArr[i].place_in_row}, " +
                $"name: {betterTupleArr[i].name}, " +
                $"surname: {betterTupleArr[i].surname}";
            ans += "}";
            if (i == tupleArr.Length - 1) ans += "]";
            else ans += $",{Environment.NewLine}";
        }
        return ans;
    }
    private static void Task7Php()
    {
        (int user_id, int place_in_row, string name, string surname)[] betterTuple = new (int user_id, int place_in_row, string name, string surname)[tupleArr.Length];
        for (int i = 0; i < betterTuple.Length; i++)
        {
            string generatedName = Task3PhpGenerateRandomLetterArray(rng.Next(5, 16)).Aggregate((x, y) => x + y);
            string generatedSurname = Task3PhpGenerateRandomLetterArray(rng.Next(5, 16)).Aggregate((x, y) => x + y);
            generatedName = $"{generatedName[0]}{generatedName.Substring(1).ToLower()}";
            generatedSurname = $"{generatedSurname[0]}{generatedSurname.Substring(1).ToLower()}";
            betterTuple[i] = (user_id: tupleArr[i].user_id, place_in_row: tupleArr[i].place_in_row, name: generatedName, surname: generatedSurname);
        }
        string stringBetterTupleArr = Task7PhpPrintBetterTupleArr(betterTuple);
        string answer = $"""
                stringBetterTupleArr: {stringBetterTupleArr}
                """;
        MyUtils.TaskDisplay("7Php", answer);
    }
    private static object[] objectArr = new object[10];
    private static void Task8Php()
    {

        for (int i = 0; i < objectArr.Length; i++)
        {
            int randomNum = rng.Next(0, 5);
            if (randomNum == 0) objectArr[i] = rng.Next(0, 11);
            else objectArr[i] = new int[randomNum].Select(_ => rng.Next(0, 11)).ToArray();
        }
        string ans = "[";
        for (int i = 0; i < objectArr.Length; i++)
        {
            try
            {
                ans += MyUtils.StringArrayJoin((int[])objectArr[i]);
            }
            catch (Exception)
            {
                ans += objectArr[i];
            }
            if (i < objectArr.Length - 1) ans += ", ";
        }
        ans += "]";

        string answer = $"""
            weirdArray: {ans}
            """;
        MyUtils.TaskDisplay("8Php", answer);
    }
    private static void Task9Php()
    {

    }
}

