using System;
using System.Globalization;
using System.Threading;

namespace FishingContest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                Fisher fisher = Search("input.txt");
                if (fisher != null)
                {
                    Console.WriteLine($"{fisher.name} " + $"a legalább fél méteres pontyokból több mint 10 kilót fogott.");
                }
                else
                {
                    Console.WriteLine("Senki sem fogott a " + "legalább fél méteres pontyokból több mint 10 kilót.");
                }
            }

            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
        }

        public static Fisher Search(string fname)
        {
            InFile f = new(fname);
            Fisher fisher;
            while((fisher=f.Read())!=null)
            {
                if (fisher.Sum >= 10.0)
                {
                    break;
                }
            }
            return fisher;
        }
    }
}
