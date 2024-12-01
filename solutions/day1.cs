using System.IO;

namespace Solutions
{
    public static class Day1
    {
        public static void part1()
        {
            string line;
            int total = 0;
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            // StreamReader sr = new StreamReader("examples/day1.txt");
            StreamReader sr = new StreamReader("problems/day1.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] pair = line.Split("   ");
                int value1 = 0;
                int value2 = 0;
                int.TryParse(pair[0], out value1);
                int.TryParse(pair[1], out value2);
                left.Add(value1);
                right.Add(value2);
            }
            left.Sort();
            right.Sort();
            var sortedList = left.Zip(right);
            foreach (var valueSet in sortedList)
            {
                int hold = Math.Abs(valueSet.First - valueSet.Second);
                total += hold;
            }
            Console.WriteLine(total);
        }

        public static void part2()
        {
            string line;
            int total = 0;
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            // StreamReader sr = new StreamReader("examples/day1.txt");
            StreamReader sr = new StreamReader("problems/day1.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] pair = line.Split("   ");
                int value1 = 0;
                int value2 = 0;
                int.TryParse(pair[0], out value1);
                int.TryParse(pair[1], out value2);
                left.Add(value1);
                right.Add(value2);
            }
            while (left.Count() > 0)
            {
                int testValue = left.First();
                var totalLeft = left.Where(x => testValue.Equals(x)).Count();
                left.RemoveAll(x => testValue.Equals(x));
                var totalRight = right.Where(x => testValue.Equals(x)).Count();
                total += testValue * totalLeft * totalRight;
            }
            Console.WriteLine(total);
        }

        // First attempt, n^2

        // public static void part2(){
        //     string line;
        //     int total = 0;
        //     List<int> left = new List<int>();
        //     List<int> right = new List<int>();
        //     // StreamReader sr = new StreamReader("examples/day1.txt");
        //     StreamReader sr = new StreamReader("problems/day1.txt");
        //     while ((line = sr.ReadLine()) != null){
        //         string[] pair = line.Split("   ");
        //         int value1 = 0;
        //         int value2 = 0;
        //         int.TryParse(pair[0], out value1);
        //         int.TryParse(pair[1], out value2);
        //         left.Add(value1);
        //         right.Add(value2);
        //     }
        //     foreach (int value in left){
        //         int totalInRight = 0;
        //         foreach (int otherValue in right){
        //             if (value==otherValue){
        //                 totalInRight += 1;
        //             }
        //         }
        //         total += value * totalInRight;
        //     }
        //     Console.WriteLine(total);
        // }
    }
}