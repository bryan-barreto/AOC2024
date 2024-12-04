using System;


namespace Solutions
{
    public static class Day4
    {
        private static bool checkChar(List<string> wordSearch, char letter, int[] currentPos, int[] direction)
        {
            int xPos = direction[0] + currentPos[0];
            int yPos = direction[1] + currentPos[1];
            if (xPos < 0 || xPos >= wordSearch.Count()) { return false; }
            if (yPos < 0 || yPos >= wordSearch[0].Count()) { return false; }
            if (wordSearch[xPos][yPos] == letter) { return true; }

            return false;
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
                            int[] direction = { x, y };
                            if (direction[0] == 0 && direction[1] == 0){continue;}
                            if (!checkChar(wordSearch, 'M', currentPos, direction)) { continue; }
                            direction[0] = direction[0]+x;
                            direction[1] = direction[1]+y;
                            if (!checkChar(wordSearch, 'A', currentPos, direction)) { continue; }
                            direction[0] = direction[0]+x;
                            direction[1] = direction[1]+y;
                            if (!checkChar(wordSearch, 'S', currentPos, direction)) { continue; }
                            total++;
                            
                        }
                    }
                }
                currentLine++;
            }
            Console.WriteLine(total);
        }

        
    }
}