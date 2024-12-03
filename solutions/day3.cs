using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Solutions
{
    public static class Day3
    {
        public static void part1()
        {
            // StreamReader sr = new StreamReader("examples/day3.txt");
            StreamReader sr = new StreamReader("problems/day3.txt");
            string line = "";
            int total = 0;
            string pattern = @"mul\(\d+,\d+\)";
            while ((line = sr.ReadLine()) != null)
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    string toSplit = match.ToString().Trim('m', 'u', 'l', '(', ')');
                    int[] values = Array.ConvertAll(toSplit.Split(","), s => int.Parse(s));
                    total += values[0] * values[1];
                }
            }
            Console.WriteLine(total);
        }

        public static void part2()
        {
            // StreamReader sr = new StreamReader("examples/day3-2.txt");
            StreamReader sr = new StreamReader("problems/day3.txt");
            string line = "";
            int total = 0;
            string pattern = @"(?:mul\(\d+,\d+\))|(?:do\(\))|(?:don't\(\))";
            bool isDo = true;
            while ((line = sr.ReadLine()) != null)
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    if (match.ToString() == "don't()")
                    {
                        isDo = false;
                    }
                    else if (match.ToString() == "do()")
                    {
                        isDo = true;
                    }
                    else if (isDo)
                    {
                        string toSplit = match.ToString().Trim('m', 'u', 'l', '(', ')');
                        int[] values = Array.ConvertAll(toSplit.Split(","), s => int.Parse(s));
                        total += values[0] * values[1];
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}