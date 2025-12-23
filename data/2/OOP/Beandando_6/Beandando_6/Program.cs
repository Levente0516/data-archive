using System.Globalization;
using TextFile;

namespace Beandando_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Megoldas(args[0]);
        }

        public static void Megoldas(string fname)
        {
            try
            {
                Console.WriteLine(Sum(fname));
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("file not found");
            }
        }

        public static int Sum(string fname)
        {
            ReadIn read = new(fname);   
            Bill bill;
            int sum = 0;
            while ((bill = read.Read()) != null)
            {
                sum += bill.Sum;
            }

            return sum;
        }
    }
}