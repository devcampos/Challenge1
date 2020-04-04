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
            var inputTask1 = "(1, 6), (2, 2), (3, 4)";
            var inputTask2 = "(1, 2)";

            var x = GetMatch(inputTask1);
            var y = GetMatch(inputTask2);


            var lastValue = 0;
            var comp = new List<string>();

            for (int i = 0; i < x.Count; i++)
            {
                var sum = 0;
                var row = x[i];
                sum = row.value;

                //Console.WriteLine($"from X Key {row.id} value {row.value}");
                for (int d = 0; d < y.Count; d++)
                {
                    var child = y[d];
                    //Console.WriteLine($"DEL y Key {child.id} valor {child.value}");
                    sum += child.value;
                    //Console.WriteLine($"Actual total value={sum}");
                    if (sum == cores)
                    {
                        //Console.WriteLine($"Es igual {row.id}, {child.id}");
                        comp.Add($"({row.id},{child.id})");
                    }

                    if (lastValue < sum && sum <= cores)
                    {
                        lastValue = sum;
                    }

                    if (i == x.Count - 1 && comp.Count == 0)
                    {
                        comp.Add($"({row.id},{child.id})");
                    }
                }
            }

            Console.WriteLine($"Input Task 1 : { String.Join(",", inputTask1)}");
            Console.WriteLine($"Input Task 2 : { String.Join(",", inputTask2)}");
            Console.WriteLine($"Final Result : { String.Join(",", comp)}");
            Console.ReadKey();

        }

        /// <summary>
        /// Method for Resolve valid input string
        /// </summary>
        /// <param name="s">String to Valid</param>
        /// <returns>List from TaskProcess object with valid string</returns>
        public static List<TaskProcess> GetMatch(string s)
        {
            Regex pattern = new Regex(@"\((\s*\d+\s*[*\,]\s*\d+)*\)");
            var r = Regex.Replace(s, @"\s +", "");
            MatchCollection matches = pattern.Matches(s);
            var result = new List<TaskProcess>();

            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    var value = capture.Value;
                    string x = value.Substring(value.IndexOf('(') + 1, value.LastIndexOf(',') - 1);
                    string y = value.Substring(value.IndexOf(',') + 1, value.IndexOf(')') - value.IndexOf(',') - 1);

                    result.Add(new TaskProcess { id = Convert.ToInt32(x), value = Convert.ToInt32(y) });
                }
            }
            return result;
        }

    }    

}
