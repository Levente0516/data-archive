using TextFile;
using System;
using System.Globalization;
using System.Threading;

namespace Beadando_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Megoldas(args[0]);
        }

        public static void Megoldas(string fname)
        {
            try
            {
                TextFileReader reader = new(fname);

                List<double> lista = new List<double>();
                double a = 0;
                int div = 0;
                bool l = false;
                bool firstCheck = true;

                //beolvasás
                while (reader.ReadLine(out string line))
                {
                    lista.Add(double.Parse(line));
                }

                double[] array = lista.ToArray();

                double min_ertek = array[0];

                //átlagszámítás
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > 0)
                    {
                        a += array[i];
                        div++;
                    }
                    else
                    {
                        break;
                    }
                }

                // negativ hőmérséklet után az összes negatív e
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < 0 & firstCheck)
                    {
                        l = true;
                        firstCheck = false;
                    }
                    if (array[i] > 0)
                    {
                        l = false;
                    }
                }

                //minkeresés
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min_ertek)
                    {
                        min_ertek = array[i];
                    }
                }

                Console.WriteLine((double)a/div);
                Console.WriteLine(l);
                Console.WriteLine(min_ertek);

            }

            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File_Not_Found");
            }
        }
    }
}
