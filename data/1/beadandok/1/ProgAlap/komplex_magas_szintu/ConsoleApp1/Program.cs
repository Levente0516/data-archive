namespace ConsoleApp1
{
    using magas_szintű_mintamegvalósítások;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void Main(string[] args)
        {
            int telepules, napok;

            string[] temp = new string[2];

            temp = Console.ReadLine().Split(' ');

            telepules = int.Parse(temp[0]);
            napok = int.Parse(temp[1]);

            int[,] matrix = new int[telepules, napok];

            string[] temp2 = new string[napok];

            for (int i = 0; i < telepules; i++)
            {
                temp2 = Console.ReadLine().Split(' ');
                for (int j = 0; j < napok; j++)
                {
                    matrix[i, j] = int.Parse(temp2[j]);
                }
            }

            int[] napok_min = new int[napok];
            int bin = 0;

            //napi minimumok megállapítása
            for (int i = 0; i < napok; i++)
            {
                (bin, napok_min[i])= Mintak.Min(0, telepules - 1 , j => matrix[j, i]);
            }

            //legnagyobb minumum

            (bin, int legnagyobb_minimum) = Mintak.Max(0, napok - 1, i => napok_min[i]);

            //kiválogatás mikor igaz

            int[] vanilyen = Mintak.Kivalogat(napok_min, min => min == legnagyobb_minimum, (min, index) => index + 1);

            Console.Write(vanilyen.Length);

            for (int i = 0; i < vanilyen.Length; i++)
            {
                Console.Write(" " + vanilyen[i]);
            }

            Console.ReadLine();
        }
    }
}

