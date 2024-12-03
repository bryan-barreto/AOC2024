using System;

namespace Solutions
{
    public static class Day2
    {
        private static bool isSafe(int[] levelInt)
        {
            string isIncreasing = "";
            for (int x = 0; x < levelInt.Count() - 1; x++)
            {
                if (Math.Abs(levelInt[x] - levelInt[x + 1]) > 3) { return false; }

                if (isIncreasing == "")
                {
                    if (levelInt[x] < levelInt[x + 1])
                    {
                        isIncreasing = "increasing";
                    }
                    else if (levelInt[x] > levelInt[x + 1])
                    {
                        isIncreasing = "decreasing";
                    }
                    else
                    {
                        return false;
                    }
                    continue;
                }

                if (levelInt[x] < levelInt[x + 1] && isIncreasing == "increasing")
                {
                    continue;
                }
                else if (levelInt[x] > levelInt[x + 1] && isIncreasing == "decreasing")
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static void part1()
        {
            int total = 0;
            string report;
            // StreamReader sr = new StreamReader("examples/day2.txt");
            StreamReader sr = new StreamReader("problems/day2.txt");
            while ((report = sr.ReadLine()) != null)
            {
                string[] levelString = report.Split(" ");
                int[] levelInt = Array.ConvertAll(levelString, a => int.Parse(a));
                if (isSafe(levelInt))
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }

        public static void part2()
        {
            int total = 0;
            string report;
            // StreamReader sr = new StreamReader("examples/day2.txt");
            StreamReader sr = new StreamReader("problems/day2.txt");
            while ((report = sr.ReadLine()) != null)
            {
                string[] levelString = report.Split(" ");
                int[] levelInt = Array.ConvertAll(levelString, a => int.Parse(a));
                // List<int> levelInt = new List<int>(levelToList);
                int removeAt = 0;
                if (isSafe(levelInt))
                {
                    total++;
                }
                else
                {
                    while (removeAt < levelInt.Count())
                    {
                        List<int> levelList = new List<int>(levelInt);
                        levelList.RemoveAt(removeAt);
                        if (isSafe(levelList.ToArray()))
                        {
                            removeAt = levelInt.Count();
                            total++;
                        }
                        else{removeAt++;}
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}