using System;


namespace Solutions
{
    public static class Day5
    {
        private static (bool, string[]?) checkRule(string[] rules, string[] pageString)
        {
            foreach (string rule in rules)
            {
                string[] ruleSplit = rule.Split("|");
                string posOne = "";
                string posTwo = "";
                for (int x = 0; x < pageString.Count(); x++)
                {
                    if (pageString[x] == ruleSplit[0]) { posOne = pageString[x]; }
                    else if (pageString[x] == ruleSplit[1]) { posTwo = pageString[x]; }
                }
                if ((Array.IndexOf(pageString, posOne) < Array.IndexOf(pageString, posTwo)) ||
                    (posOne == "" && posTwo == ruleSplit[1]) ||
                    (posOne == ruleSplit[0] && posTwo == "") ||
                    (posOne == "" && posTwo == ""))
                { }
                else
                {
                    string[] pos = { posOne, posTwo };
                    return (false, pos);
                }
            }
            return (true, null);
        }

        public static void part1()
        {
            // string sr = new StreamReader("examples/day5.txt").ReadToEnd();
            string sr = new StreamReader("problems/day5.txt").ReadToEnd();
            string line = "";
            int total = 0;

            string[] srSplit = sr.Split("\r\n\r\n");
            string[] rules = srSplit[0].Split("\r\n");
            string[] pages = srSplit[1].Split("\r\n");

            List<string[]> setOfPages = new List<string[]>();

            foreach (string set in pages)
            {
                string[] pageString = set.Split(",");


                bool addToList = true;
                foreach (string rule in rules)
                {
                    if (addToList == false) { continue; }
                    string[] ruleSplit = rule.Split("|");
                    string posOne = "";
                    string posTwo = "";
                    for (int x = 0; x < pageString.Count(); x++)
                    {
                        if (pageString[x] == ruleSplit[0]) { posOne = pageString[x]; }
                        else if (pageString[x] == ruleSplit[1]) { posTwo = pageString[x]; }
                    }
                    if ((Array.IndexOf(pageString, posOne) < Array.IndexOf(pageString, posTwo)) ||
                        (posOne == "" && posTwo == ruleSplit[1]) ||
                        (posOne == ruleSplit[0] && posTwo == "") ||
                        (posOne == "" && posTwo == ""))
                    { }
                    else { addToList = false; }
                }
                if (addToList) { setOfPages.Add(pageString); }
            }

            foreach (string[] list in setOfPages)
            {
                total += Int32.Parse(list[(list.Count() - 1) / 2]);
            }

            Console.WriteLine(total);
        }

        public static void part2()
        {
            // string sr = new StreamReader("examples/day5.txt").ReadToEnd();
            string sr = new StreamReader("problems/day5.txt").ReadToEnd();
            int total = 0;

            string[] srSplit = sr.Split("\r\n\r\n");
            string[] rules = srSplit[0].Split("\r\n");
            string[] pages = srSplit[1].Split("\r\n");

            var badList = new Stack<object[]>();
            List<string[]> goodList = new List<string[]>();

            foreach (string set in pages)
            {
                string[] pageString = set.Split(",");
                var checkrule = checkRule(rules, pageString);
                if (!checkrule.Item1)
                {
                    object[] addToBadList = { pageString, checkrule.Item2 };
                    badList.Push(addToBadList);
                }
            }

            while (badList.Count() > 0)
            {
                object[] fixString = badList.Pop();
                string[] fixPage = (string[])fixString[0];
                string[] fixRules = (string[])fixString[1];
                for (int x = 0; x < fixPage.Count(); x++)
                {
                    if (fixPage[x] == fixRules[1])
                    {
                        fixPage[x] = fixRules[0];
                        continue;
                    }
                    if (fixPage[x] == fixRules[0])
                    {
                        fixPage[x] = fixRules[1];
                        continue;
                    }
                }
                (bool, string[]?) isGoodYet = checkRule(rules, fixPage);
                if (!isGoodYet.Item1)
                {
                    object[] addToBadList = { fixPage, isGoodYet.Item2 };
                    badList.Push(addToBadList);
                }
                else { goodList.Add(fixPage);}
            }

            foreach (string[] list in goodList)
            {
                total += Int32.Parse(list[(list.Count() - 1) / 2]);
            }

            Console.WriteLine(total);
        }
    }
}