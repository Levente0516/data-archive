using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;

namespace Gyak03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a tomb hosszat: ");

            int hossz = int.Parse(Console.ReadLine());

            int[] tomb = new int[hossz];

            Console.WriteLine("Adjon meg " + hossz + "db szamot: ");

            for (int i = 0; i < hossz; i++)
            {
                tomb[i] = int.Parse(Console.ReadLine());
            }

            //Kiiratás
            
            for (int i = 0; i < hossz; i++)
            {
                Console.Write(tomb[i] + " ");
            }

            Console.WriteLine();

            //Max keresés

            int max = 0;

            for (int i = 0; i < hossz; i++)
            {
                if (tomb[i] >= max)
                {
                    max = tomb[i];
                }
            }

            //Min keresés

            Console.WriteLine("Legnagyobb szam: " + max);

            int min = max + 1;

            for (int i = 0; i < hossz; i++)
            {
                if (tomb[i] <= min)
                {
                    min = tomb[i];
                }
            }

            Console.WriteLine("Legkisebb szam: " + min);

            //Van-e ismétlődő szám és ha igen akkor melyik az?

            int[] tomb_2 = new int[hossz];
            int j = 0;

            for (int i = 0; i < hossz; i++)
            {
                for (int t = 0; t < hossz; t++)
                {
                    if (tomb[i] != tomb_2[t])
                    {
                        j++;
                        if (j == hossz)
                        {
                            tomb_2[i] = tomb[i];
                            j = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("A " + tomb[i] + " ismetlodik" );
                        j = 0;
                    }
                }
            }
        }
    }
}
