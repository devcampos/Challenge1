using Challenge1.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Challenge1.Service
{
    public class Service : IService
    {
        public string PrintMatchResult { get; private set; }

        public List<string> Process(int cores, string task1, string task2)
        {
            var lastValue = 0;
            var comp = new List<string>();

            var x = GetMatch(task1);
            var y = GetMatch(task2);
            var Lasttask = "";

            for (int i = 0; i < x.Count; i++)
            {
                for (int d = 0; d < y.Count; d++)
                {
                    var sum = x[i].value + y[d].value;
                    if (sum == cores)
                    {
                        comp.Add($"({x[i].id},{y[d].id})");
                    }
                }
            }
            if (comp.Count <= 1)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    for (int d = 0; d < y.Count; d++)
                    {
                        var sum = x[i].value + y[d].value;
                        if (lastValue < sum && sum <= cores)
                        {
                            lastValue = sum;
                            Lasttask = $"({x[i].id},{y[d].id})";
                        }
                    }
                    if (i == x.Count - 1)
                        comp.Add(Lasttask);
                }
            }
            return comp;
        }

        /// <summary>
        /// Method for Resolve valid input string
        /// </summary>
        /// <param name="s">String to Valid</param>
        /// <returns>List from TaskProcess object with valid string</returns>
        public List<TaskProcess> GetMatch(string s)
        {
            Regex pattern = new Regex(@"\((\s*\d+\s*[*\,]\s*\d+)*\)");
            var r = Regex.Replace(s, @"\s +", "");
            MatchCollection matches = pattern.Matches(r);
            var result = new List<TaskProcess>();
            var forPrint = "";
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    var value = capture.Value;
                    string x = value.Substring(value.IndexOf('(') + 1, value.LastIndexOf(',') - 1);
                    string y = value.Substring(value.IndexOf(',') + 1, value.IndexOf(')') - value.IndexOf(',') - 1);

                    result.Add(new TaskProcess { id = Convert.ToInt32(x), value = Convert.ToInt32(y) });
                    forPrint += capture.Value;
                }
            }
            PrintMatchResult = forPrint;
            return result;
        }

        /// <summary>
        /// Print result of match Results
        /// </summary>
        public void PrintCorrectlyMatch()
        {
            Console.WriteLine(PrintMatchResult);
        }


    }
}
