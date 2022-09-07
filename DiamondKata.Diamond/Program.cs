using System;
using DiamondKata.DiamondKataLib;

namespace DiamondKata.Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            const string INVALID_PARAM_ERROR_MESSAGE = "Invalid parameters. Please provide a single capital letter between A and Z.";

            if (args.Length != 1 || args[0].Length != 1)
            {
                Console.Error.WriteLine(INVALID_PARAM_ERROR_MESSAGE);
                Environment.Exit(1);
            }

            try
            {
                char inputCharacter = args[0][0];
                DiamondBuilder diamondBuilder = new DiamondBuilder(inputCharacter);
                Console.Write(diamondBuilder.Build());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine(INVALID_PARAM_ERROR_MESSAGE);
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
