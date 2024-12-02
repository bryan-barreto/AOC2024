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
                for (int x = 0; x < levelInt.Count()-1; x++)
                {
                    if (!isSafe)
                    {
                        continue;
                    }
                    if (Math.Abs(levelInt[x]-levelInt[x+1])>3){
                        isSafe = false;
                        continue;
                    }
                    if (isIncreasing == "")
                    {
                        if (levelInt[x] < levelInt[x + 1])
                        {
                            isIncreasing = "increasing";
                        }
                        else if(levelInt[x] > levelInt[x + 1])
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
                    else if(levelInt[x] > levelInt[x + 1] && isIncreasing == "decreasing")
                    {
                        continue;
                    }
                    else{
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
    }
}