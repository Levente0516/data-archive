using System;

/*
Nagy Levente
UJI470
levente0517@gmail.com
*/

class Program
{
    public struct Bor
    {
        public int mennyiseg;
        public int ar;
        public Bor(int a, int b)
        {
            mennyiseg = a;
            ar = b;
        }
    }
    static void Main(string[] args)
    {
        int db = int.Parse(Console.ReadLine());

        Bor[] borAdat = new Bor[db];

        string[] temp = new string[db];

        for (int i = 0; i < db; i++)
        {
            temp = Console.ReadLine().Split(' ');

            borAdat[i] = new Bor(int.Parse(temp[0]), int.Parse(temp[1]));
        }

        int maxertek = borAdat[0].mennyiseg;
        int[] tomb = new int[db];
        int j = 0;

        for (int i = 1; i < db; i++)
        {
            if (borAdat[i].mennyiseg > maxertek)
            {
                maxertek = borAdat[i].mennyiseg;
                tomb[j] = i + 1;
                j++;
            }     
        }

        Console.Write(j + " ");

        for (int i = 0; i < j; i++)
        {
            Console.Write(tomb[i] + " ");
        }

    }
}
