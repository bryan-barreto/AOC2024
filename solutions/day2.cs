using System.Diagnostics;

namespace Solutions
{
    public static class Day2
    {

        // private class NewReport
        // {

        //     string isSafe;
        //     string isIncreasing;

        // }
        public static void part1()
        {
            int total = 0;
            string report;
            // StreamReader sr = new StreamReader("examples/day2.txt");
            StreamReader sr = new StreamReader("problems/day2.txt");
            while ((report = sr.ReadLine()) != null)
            {
                bool isSafe = true;
                string isIncreasing = "";
                string[] levelString = report.Split(" ");
                int[] levelInt = Array.ConvertAll(levelString, a => int.Parse(a));
                for (int x = 0; x < levelInt.Count() - 1; x++)
                {
                    if (!isSafe)
                    {
                        continue;
                    }
                    if (Math.Abs(levelInt[x] - levelInt[x + 1]) > 3)
                    {
                        isSafe = false;
                        continue;
                    }
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
                            isSafe = false;
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
                        isSafe = false;
                    }
                }
                if (isSafe)
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
                bool dampened = false;
                bool isSafe = true;
                string isIncreasing = "";
                string[] levelString = report.Split(" ");
                int[] levelToList = Array.ConvertAll(levelString, a => int.Parse(a));
                List<int> levelInt = new List<int>(levelToList);
                for (int x = 0; x < levelInt.Count() - 1; x++)
                {
                    if (Math.Abs(levelInt[x] - levelInt[x + 1]) > 3)
                    {
                        isSafe = false;
                    }
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
                            isSafe = false;
                        }

                    }
                    if (levelInt[x] < levelInt[x + 1] && isIncreasing == "increasing")
                    {

                    }
                    else if (levelInt[x] > levelInt[x + 1] && isIncreasing == "decreasing")
                    {

                    }
                    else
                    {
                        isSafe = false;
                    }
                    if (!isSafe && !dampened)
                    {
                        levelInt.RemoveAt(x);
                        isSafe = true;
                        dampened = true;
                        if (x == 1)
                        {
                            isIncreasing = "";
                        }
                        if (x >= levelInt.Count())
                        {
                            break;
                        }
                        x--;
                    }
                    if (!isSafe)
                    {
                        break;
                    }
                }
                if (isSafe)
                {
                    total++;
                }
            }
            Console.WriteLine(total);
        }
    }
}