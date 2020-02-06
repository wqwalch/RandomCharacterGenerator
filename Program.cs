using System;
using System.Collections.Generic;
using System.IO;

namespace RandomCharacterGenerator
{
    class Program
    {
        const string PRINTABLE_STRINGS = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
        static void Main(string[] args)
        {
            bool printingToOutput = false;
            bool printPretty = false;
            string printTo = Directory.GetCurrentDirectory();
            long numofChars = -1;

            if (args.Length == 0)
            {
                printingToOutput = true;
            }
            else if (args[0].ToUpper() == "--PRETTY")
            {
                printingToOutput = true;
                printPretty = true;
            }
            else if (args[0].ToUpper() == "--H" || args[0].ToUpper() == "--HELP")
            {
                PrintHelp();
                return;
            }
            else
            {
                printingToOutput = long.TryParse(args[0], out numofChars);
                if (!printingToOutput)
                {
                    printTo += args[0];
                    long.TryParse(args[1], out numofChars);
                }

                if (args[args.Length - 1].ToUpper() == "--PRETTY")
                {
                    printPretty = true;
                }
            }

            Random random = new Random();
            long numPrinted = 0;
            using (var sw = printingToOutput ? new StreamWriter(Console.OpenStandardOutput()) : new StreamWriter(printTo))
            {
                for (numPrinted = 0; numPrinted < numofChars || numofChars == -1; numPrinted++)
                {
                    if (printPretty)
                    {
                        int rnd = random.Next(PRINTABLE_STRINGS.Length - 1);
                        sw.Write(PRINTABLE_STRINGS[rnd]);
                    }
                    else
                    {
                        int rnd = random.Next(255);
                        sw.Write((char)(rnd));
                    }
                }
            }
            if(!printingToOutput)
            {
                Console.WriteLine("Wrote " + numPrinted + " characters to " + printTo);
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("Usage: ./rndChrs.exe [OUTPUTFILE] [NUMCHARS] [--PRETTY]");
            Console.WriteLine("Prints out a string of random characters to a file or console.");
            Console.WriteLine("  OUTPUTFILE is the optional file to print to.");
            Console.WriteLine("  NUMCHARS is the optional number of characters, if not specified, it will print infinitely.");
            Console.WriteLine("  --PRETTY is the optional filter to exclude unprintable characters");
            Console.WriteLine("Examples: ");
            Console.WriteLine("  ./rndChrs.exe ./outputfolder/junk.txt 10000");
            Console.WriteLine("     Will write 10,000 characters to junk.txt");
            Console.WriteLine("  ./rndChrs.exe 50 --pretty");
            Console.WriteLine("     Will output 50 printable characters to console");
        }
    }
}
