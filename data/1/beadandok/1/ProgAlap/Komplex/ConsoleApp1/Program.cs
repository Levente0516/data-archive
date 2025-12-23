namespace ConsoleApp1
{
    using System;

    /*
    Nagy Levente
    UJI470
    levente0517@gmail.com
    */
    internal class Program
    {
        static void Main(string[] args)
        {

            int telepules, napok;

            string[] temp = new string[2];

            temp = Console.ReadLine().Split(' ');

            telepules = int.Parse(temp[0]);
            napok = int.Parse(temp[1]);

            int[,] matrix = new int[telepules,napok];

            string[] temp2 = new string[napok];

            for (int i = 0; i < telepules; i++)
            {
                temp2 = Console.ReadLine().Split(' ');
                for (int j = 0; j < napok; j++)
                {
                    matrix[i,j] = int.Parse(temp2[j]);
                }
            }

            //napi minimumok megállapítása

            int[] napok_min = new int[napok];

            for (int i = 0; i < napok; i++)
            {
                int temp_min = matrix[0,i];
                for (int j = 1; j < telepules; j++)
                {
                    if (matrix[j,i] < temp_min)
                    {
                        temp_min = matrix[j,i];
                    }
                }
                napok_min[i] = temp_min;
            }

            //legnagyobb minumum

            int legnagyobb_minimum = napok_min[0];

            for (int i = 1; i < napok; i++)
            {
                if (napok_min[i] > legnagyobb_minimum)
                {
                    legnagyobb_minimum = napok_min[i];
                }
            }

            //kiválogatás mikor igaz

            int[] vanilyen = new int[napok];
            int t = 0;

            for (int i = 0; i < napok; i++)
            {
                if (napok_min[i] == legnagyobb_minimum)
                {
                    vanilyen[t] = i + 1;
                    t++;
                }
            }

            Console.Write(t + " ");
            for (int i = 0; i < t; i++)
            {
                Console.Write(vanilyen[i] + " ");
            }

            Console.ReadLine();
        }
    }
}