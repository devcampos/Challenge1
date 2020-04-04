using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {

            var cores = 7;

            var inputTask1 = GetMatch("(1, 6), (2, 2), (3, 4)");
            var inputTask2 = GetMatch("(1, 2)");


            var lastValue = 0;
            var comp = new List<string>();

            for (int i = 0; i < inputTask1.Count; i++)
            {
                var sum = 0;
                var row = inputTask1[i];
                sum = row.value;

                Console.WriteLine($"from X Key {row.id} value {row.value}");
                for (int d = 0; d < inputTask2.Count; d++)
                {
                    var child = inputTask2[d];
                    Console.WriteLine($"DEL y Key {child.id} valor {child.value}");
                    sum += child.value;
                    Console.WriteLine($"Actual total value={sum}");
                    if (sum == cores)
                    {
                        Console.WriteLine($"Es igual {row.id}, {child.id}");
                        comp.Add($"({row.id},{child.id})");
                    }

                    if (lastValue < sum && sum <= cores)
                    {
                        lastValue = sum;
                    }

                    if (i == inputTask1.Count - 1 && comp.Count == 0)
                    {
                        comp.Add($"({row.id},{child.id})");
                    }
                }
            }

            Console.WriteLine($"Correctly rows : { String.Join(",", inputTask1)}");
            Console.ReadKey();

        }

        /// <summary>
        /// Method for Resolve valid input string
        /// </summary>
        /// <param name="s">String to Valid</param>
        /// <returns>List from TaskProcess object with valid string</returns>
        public static List<TaskProcess> GetMatch(string s)
        {
            Regex pattern = new Regex(@"\(([\d\s][*\,][\d\s])*\)");
            MatchCollection matches = pattern.Matches(s);
            var result = new List<TaskProcess>();

            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    var pedazo = capture.Value;
                    string x = pedazo.Substring(pedazo.IndexOf('(') + 1, pedazo.LastIndexOf(',') - 1);
                    string y = pedazo.Substring(pedazo.IndexOf(',') + 1, pedazo.IndexOf(')') - pedazo.IndexOf(',') - 1);

                    result.Add(new TaskProcess { id = Convert.ToInt32(x), value = Convert.ToInt32(y) });
                }
            }
            return result;
        }

    }    

}
