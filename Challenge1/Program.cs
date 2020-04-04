using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Give me a Number of Core:");            
            int coreValue = 0;
            string foregroundValue = "";
            string backgroundValue = "";
         
            do
            {
                if (int.TryParse(Console.ReadLine(), out coreValue) && coreValue != 0)
                {
                    Console.WriteLine("Give me a List of foreground tasks with this format (5,8),(7,8):");
                    foregroundValue = Console.ReadLine();
                    if (!string.IsNullOrEmpty(foregroundValue))
                    {
                        Console.WriteLine("Give me a List of background tasks with this format (1,0),(1,1):");
                        backgroundValue = Console.ReadLine();
                        if (!string.IsNullOrEmpty(backgroundValue))
                        {
                            DI sv = new DI(new Service.Service());            
                            Console.WriteLine($"Final Result : {sv.Run(coreValue, foregroundValue, backgroundValue)}");
                            Console.WriteLine("Press any key for exit, thank you i hope soon.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("List of background tasks is empty, try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("List of foreground tasks is empty, try again");
                    }
                }
                else
                {
                    Console.WriteLine("Not is an integer. try again please.");
                }
            }
            while (coreValue == 0 && string.IsNullOrEmpty(foregroundValue) && string.IsNullOrEmpty(backgroundValue));                   
        }
    }    

}
