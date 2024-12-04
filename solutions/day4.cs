using System;


namespace Solutions
{
    public static class Day4
    {
        private static char? checkChar(List<string> wordSearch, int[] currentPos, int[] direction)
        {
            int xPos = direction[0] + currentPos[0];
            int yPos = direction[1] + currentPos[1];
            if (xPos < 0 || xPos >= wordSearch.Count()) { return null; }
            if (yPos < 0 || yPos >= wordSearch[0].Count()) { return null; }
            return wordSearch[xPos][yPos];
        }

        public static void part1()
        {
            // StreamReader sr = new StreamReader("examples/day4.txt");
            StreamReader sr = new StreamReader("problems/day4.txt");
            string line = "";
            int total = 0;

            List<string> wordSearch = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                wordSearch.Add(line);
            }

            int currentLine = 0;
            // int[,] directions = { { 0, 1 }, { 1, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 }, { -1, -1 }, { -1, 1 }, { 1, -1 } };
            foreach (string readLine in wordSearch)
            {
                int currentRow = 0;
                foreach (char testChar in readLine)
                {
                    int[] currentPos = { currentLine, currentRow };
                    currentRow++;
                    if (testChar != 'X') { continue; }
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            string xmas = "X";
                            int[] direction = { x, y };
                            if (direction[0] == 0 && direction[1] == 0) { continue; }
                            char? holdChar = checkChar(wordSearch, currentPos, direction);
                            if (holdChar == null) { continue; }
                            else { xmas += holdChar; }
                            direction[0] = direction[0] + x;
                            direction[1] = direction[1] + y;
                            holdChar = checkChar(wordSearch, currentPos, direction);
                            if (holdChar == null) { continue; }
                            else { xmas += holdChar; }
                            direction[0] = direction[0] + x;
                            direction[1] = direction[1] + y;
                            holdChar = checkChar(wordSearch, currentPos, direction);
                            if (holdChar == null) { continue; }
                            else { xmas += holdChar; }
                            if (xmas == "XMAS") { total++; }
                        }
                    }
                }
                currentLine++;
            }
            Console.WriteLine(total);
        }

        public static void part2()
        {
            // StreamReader sr = new StreamReader("examples/day4.txt");
            StreamReader sr = new StreamReader("problems/day4.txt");
            string line = "";
            int total = 0;

            List<string> wordSearch = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                wordSearch.Add(line);
            }

            int currentLine = 0;
            foreach (string readLine in wordSearch)
            {
                int currentRow = 0;
                foreach (char testChar in readLine)
                {
                    int[] currentPos = { currentLine, currentRow };
                    currentRow++;
                    if (testChar != 'A') { continue; }

                    int[] direction = { -1, -1 };
                    string smString = "";
                    // if (direction[0] == 0 && direction[1] == 0) { continue; }
                    try
                    {
                        smString += checkChar(wordSearch, currentPos, direction);
                        direction[0] = 1;
                        direction[1] = 1;
                        smString += checkChar(wordSearch, currentPos, direction);
                        if (smString != "SM"&& smString!="MS"){continue;}

                        smString = "";
                        direction[0] = -1;
                        direction[1] = 1;
                        smString += checkChar(wordSearch, currentPos, direction);
                        direction[0] = 1;
                        direction[1] = -1;
                        smString += checkChar(wordSearch, currentPos, direction);
                        if (smString != "SM"&& smString!="MS"){continue;}
                        total++;
                    }
                    catch
                    {
                        continue;
                    }
                }
                currentLine++;
            }
            Console.WriteLine(total);
        }
    }
}