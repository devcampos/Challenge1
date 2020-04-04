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

            var s = new Service.Service();            
            var x = s.GetMatch(inputTask1);
            s.PrintCorrectlyMatch();
            var y = s.GetMatch(inputTask2);
            s.PrintCorrectlyMatch();

            var result = s.Process(cores, inputTask1, inputTask2);
                    
            Console.WriteLine($"Final Result : { String.Join(",", result)}");
            Console.ReadKey();

        }

    

    }    

}
