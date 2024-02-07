using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilniusCodingCSharp;

namespace VilniusCodingDay1
{
    public class Day1
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
            Task7();
            Task8();
            Task9();
            Task10();
            Console.WriteLine();
        }

        private static void Task1()
        {
            string firstName = "Žilvinas";
            string lastName = "Kančys";
            DateTime birthDate = new DateTime(1995, 6, 6);
            DateTime currentDate = DateTime.Now;
            TimeSpan difference = currentDate - birthDate;
            int age = difference.Days / 365;

            string answer = $"""
                firstName: {firstName}
                lastName: {lastName}
                birthDate: {birthDate}
                currentDate: {currentDate}
                age: {age}
                """;
            MyUtils.TaskDisplay(1, answer);
        }
        private static void Task2()
        {
            Random rng = new Random();
            int min = 0, max = 5;
            double num1 = rng.Next(min, max);
            double num2 = rng.Next(min, max);
            double answerNum = 0;
            bool isZeroError = false;
            string zeroErrorMessage = "Can't divide by zero!";

            if (num2 == 0)
            {
                isZeroError = true;
            }
            else if (num1 > num2)
            {
                answerNum = num1 / num2;
                answerNum = Math.Round(answerNum, 2);
            }
            else if (num1 < num2)
            {
                answerNum = num2 / num1;
                answerNum = Math.Round(answerNum, 2);
            }
            else
            {
                answerNum = 1;
            }

            string safeAnswer = isZeroError ? zeroErrorMessage : answerNum.ToString();
            string answer = $"""
                num1: {num1}
                num2: {num2}
                answer: {safeAnswer}
                """;
            MyUtils.TaskDisplay(2, answer);
        }
        private static void Task3()
        {
            Random rng = new Random();
            int min = 0, max = 26;

            int num1 = rng.Next(min, max);
            int num2 = rng.Next(min, max);
            int num3 = rng.Next(min, max);
            int ans = min;

            if (num1 == num2 || num1 == num3 || (num1 > num3 && num1 < num2) || (num1 < num3 && num1 > num2))
                ans = num1;
            else if (num2 == num3 || (num1 > num2 && num2 > num3) || (num1 < num2 && num2 < num3))
                ans = num2;
            else
                ans = num3;

            string answer = $"""
                num1: {num1}
                num2: {num2}
                num3: {num3}
                midValue: {ans}
                """;
            MyUtils.TaskDisplay(3, answer);
        }
        private static void Task4()
        {
            Random rng = new Random();
            int min = 1, max = 11;

            int a = rng.Next(min, max);
            int b = rng.Next(min, max);
            int c = rng.Next(min, max);

            bool isntTriangle = a + b < c || b + c < a || a + c < b;
            string ans = isntTriangle ? "nope" : "yep";

            string answer = $"""
                a: {a}
                b: {b}
                c: {c}
                can it be triangle?: {ans} 
                """;
            MyUtils.TaskDisplay(4, answer);
        }
        private static void Task5()
        {
            Random rng = new Random();
            int min = 0, max = 3;

            int num1 = rng.Next(min, max);
            int num2 = rng.Next(min, max);
            int num3 = rng.Next(min, max);
            int num4 = rng.Next(min, max);
            int c0 = 0, c1 = 0, c2 = 0;

            if (num1 == 0) c0++;
            if (num2 == 0) c0++;
            if (num3 == 0) c0++;
            if (num4 == 0) c0++;

            if (num1 == 1) c1++;
            if (num2 == 1) c1++;
            if (num3 == 1) c1++;
            if (num4 == 1) c1++;

            if (num1 == 2) c2++;
            if (num2 == 2) c2++;
            if (num3 == 2) c2++;
            if (num4 == 2) c2++;


            string answer = $"""
                num1: {num1}
                num2: {num2}
                num3: {num3}
                num4: {num4}

                count0: {c0}
                count1: {c1}
                count2: {c2}
                """;
            MyUtils.TaskDisplay(5, answer);
        }
        private static void Task6()
        {
            Random rng = new Random();
            int min = 0, max = 26;

            int num1 = rng.Next(min, max);
            int num2 = rng.Next(min, max);
            int num3 = rng.Next(min, max);
            int c0 = 0, c1 = 0, c2 = 0;

            if (num1 < 0) c0++;
            if (num2 < 0) c0++;
            if (num3 < 0) c0++;

            if (num1 == 0) c1++;
            if (num2 == 0) c1++;
            if (num3 == 0) c1++;

            if (num1 > 0) c2++;
            if (num2 > 0) c2++;
            if (num3 > 0) c2++;

            string str1 = "[";
            if (c0 > 0)
            {
                int count = 0;
                if (num1 < 0)
                {
                    count++;
                    str1 += num1;
                }
                if (num2 < 0)
                {
                    if (count > 0) str1 += ",";
                    count++;
                    str1 += num2;
                }
                if (num3 < 0)
                {
                    if (count > 0) str1 += ",";
                    str1 += num3;
                }
            }
            str1 += "]";

            string str2 = "(";
            if (c1 > 0)
            {
                int count = 0;
                if (num1 == 0)
                {
                    count++;
                    str2 += num1;
                }
                if (num2 == 0)
                {
                    if (count > 0) str2 += ",";
                    count++;
                    str2 += num2;
                }
                if (num3 == 0)
                {
                    if (count > 0) str2 += ",";
                    str2 += num3;
                }
            }
            str2 += ")";

            string str3 = "{";
            if (c2 > 0)
            {
                int count = 0;
                if (num1 > 0)
                {
                    count++;
                    str3 += num1;
                }
                if (num2 > 0)
                {
                    if (count > 0) str3 += ",";
                    count++;
                    str3 += num2;
                }
                if (num3 > 0)
                {
                    if (count > 0) str3 += ",";
                    str3 += num3;
                }
            }
            str3 += "}";


            string ans = str1 + str2 + str3;

            string answer = $"""
                num1: {num1}
                num2: {num2}
                num3: {num3}
                answer: {ans}
                """;

            MyUtils.TaskDisplay(6, answer);
        }
        private static void Task7()
        {
            Random rng = new Random();
            int min = 5, max = 3001;

            int candles = rng.Next(min, max);
            int priceCents = 100;
            int ogPrice = priceCents / 100;
            int discount = 0;

            if (candles > 1000)
            {
                discount = 3;
            }
            if (candles > 2000)
            {
                discount++;
            }

            int totalCostCents = (priceCents - discount) * candles;
            double totalCost = Math.Round((double)totalCostCents / 100, 2);

            string answer = $"""
                candles: {candles}
                original price: {ogPrice} Eur
                discount: {discount}%
                total cost: {totalCost} Eur
                """;
            MyUtils.TaskDisplay(7, answer);
        }
        private static void Task8()
        {
            Random rng = new Random();
            int min = 0, max = 101;

            int num1 = rng.Next(min, max);
            int num2 = rng.Next(min, max);
            int num3 = rng.Next(min, max);
            int count = 3;

            float average = ((float)num1 + (float)num2 + (float)num3) / 3;

            float sum = 0;
            if (num1 > 10 || num1 < 90)
                sum += num1;
            else count--;
            if (num2 > 10 || num2 < 90)
                sum += num2;
            else count--;
            if (num3 > 10 || num3 < 90)
                sum += num3;
            else count--;

            string changedAverage = count == 0 ? "Can't divide by zero!" : Math.Round(sum / count, 0).ToString();


            string answer = $"""
                num1: {num1}
                num2: {num2}
                num3: {num3}
                average: {average}
                (10;90) average: {changedAverage}
                """;
            MyUtils.TaskDisplay(8, answer);
        }
        private static void Task9()
        {
            Random rng = new Random();

            bool isFullFormat = true;
            int hour = rng.Next(0, 24);
            int minute = rng.Next(0, 60);
            int second = rng.Next(0, 60);

            int extraSecond = rng.Next(0, 301);

            string hourConverted = isFullFormat ? hour.ToString() : (hour % 12).ToString();
            string minuteConverted = minute < 10 ? $"0{minute}" : minute.ToString();
            string secondConverted = second < 10 ? $"0{second}" : second.ToString();

            int sumSecond = second + extraSecond;
            int extraMinute = sumSecond / 60;

            int sumMinute = minute + extraMinute;
            int extraHour = sumMinute / 60;

            int sumHour = hour + extraHour;

            int newHour = isFullFormat ? sumHour % 24 : sumHour % 12;
            int newMinute = sumMinute % 60;
            int newSecond = sumSecond % 60;

            string newMinuteConverted = newMinute < 10 ? $"0{newMinute}" : newMinute.ToString();
            string newSecondConverted = newSecond < 10 ? $"0{newSecond}" : newSecond.ToString();

            string answer = $"""
                first gen: {hour}:{minuteConverted}:{secondConverted}
                extra seconds: {extraSecond}
                second gen: {newHour}:{newMinuteConverted}:{newSecondConverted}
                """;
            MyUtils.TaskDisplay(9, answer);
        }
        private static void Task10()
        {
            var rng = new Random();
            int min = 1000, max = 10000;

            int num1 = rng.Next(min, max);
            int num2 = rng.Next(min, max);
            int num3 = rng.Next(min, max);
            int num4 = rng.Next(min, max);
            int num5 = rng.Next(min, max);
            int num6 = rng.Next(min, max);

            int pos1 = num1;
            int pos2 = num2;
            int pos3 = num3;
            int pos4 = num4;
            int pos5 = num5;
            int pos6 = num6;

            // 1
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2; pos2 = temp;
            }
            if (pos2 > pos3)
            {
                int temp = pos2;
                pos2 = pos3; pos3 = temp;
            }
            if (pos3 > pos4)
            {
                int temp = pos3;
                pos3 = pos4; pos4 = temp;
            }
            if (pos4 > pos5)
            {
                int temp = pos4;
                pos4 = pos5; pos5 = temp;
            }
            if (pos5 > pos6)
            {
                int temp = pos5;
                pos5 = pos6; pos6 = temp;
            }

            // 2
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2; pos2 = temp;
            }
            if (pos2 > pos3)
            {
                int temp = pos2;
                pos2 = pos3; pos3 = temp;
            }
            if (pos3 > pos4)
            {
                int temp = pos3;
                pos3 = pos4; pos4 = temp;
            }
            if (pos4 > pos5)
            {
                int temp = pos4;
                pos4 = pos5; pos5 = temp;
            }
            if (pos5 > pos6)
            {
                int temp = pos5;
                pos5 = pos6; pos6 = temp;
            }

            // 3
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2; pos2 = temp;
            }
            if (pos2 > pos3)
            {
                int temp = pos2;
                pos2 = pos3; pos3 = temp;
            }
            if (pos3 > pos4)
            {
                int temp = pos3;
                pos3 = pos4; pos4 = temp;
            }
            if (pos4 > pos5)
            {
                int temp = pos4;
                pos4 = pos5; pos5 = temp;
            }
            if (pos5 > pos6)
            {
                int temp = pos5;
                pos5 = pos6; pos6 = temp;
            }

            // 4
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2; pos2 = temp;
            }
            if (pos2 > pos3)
            {
                int temp = pos2;
                pos2 = pos3; pos3 = temp;
            }
            if (pos3 > pos4)
            {
                int temp = pos3;
                pos3 = pos4; pos4 = temp;
            }
            if (pos4 > pos5)
            {
                int temp = pos4;
                pos4 = pos5; pos5 = temp;
            }
            if (pos5 > pos6)
            {
                int temp = pos5;
                pos5 = pos6; pos6 = temp;
            }

            // 5
            if (pos1 > pos2)
            {
                int temp = pos1;
                pos1 = pos2; pos2 = temp;
            }
            if (pos2 > pos3)
            {
                int temp = pos2;
                pos2 = pos3; pos3 = temp;
            }
            if (pos3 > pos4)
            {
                int temp = pos3;
                pos3 = pos4; pos4 = temp;
            }
            if (pos4 > pos5)
            {
                int temp = pos4;
                pos4 = pos5; pos5 = temp;
            }
            if (pos5 > pos6)
            {
                int temp = pos5;
                pos5 = pos6; pos6 = temp;
            }

            string answer = $"""
                num1: {num1}
                num2: {num2}
                num3: {num3}
                num4: {num4}
                num5: {num5}
                num6: {num6}
                ordered: [{pos1},{pos2},{pos3},{pos4},{pos5},{pos6}]
                """;
            MyUtils.TaskDisplay(10, answer);
        }
    }
}
