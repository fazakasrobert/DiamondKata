using System;
using DiamondKata.DiamondKataLib;

namespace DiamondKata.DiamondKataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || args[0].Length != 1)
            {
                Console.Error.WriteLine("Invalid parameters. Please provide a single capital letter between A and Z.");
                Environment.Exit(1);
            }
 
            try
            {
                char inputChar = args[0][0];
                DiamondBuilder diamond = new DiamondBuilder(inputChar);
                Console.Write(diamond.Build());    
            }
            catch (ArgumentOutOfRangeException)
            {   
                Console.Error.WriteLine("Invalid character. Please provide a single capital letter between A and Z.");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Unexpected error during execution.");
                Environment.Exit(1);
            }
        }
    }
}
