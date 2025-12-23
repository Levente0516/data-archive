using System.ComponentModel.Design;
using System.Diagnostics;

namespace Gyak03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 tömb beolvasása

            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }



            // 2

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            // 3

            int u = 0;

            while (u < n && arr[u] <= 41)
            {
                Console.Write(arr[u] + " ");
                u++;
            }

            Console.WriteLine();

            // 4

            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 7 == 0)
                {
                     Console.Write(arr[i] + " ");
                }
            }

            Console.WriteLine();
            

            // 5

            int szum = 0;

            for (int i = 0; i < n; i++)
            {
                szum += arr[i];
            }
            Console.WriteLine(szum);

            // 6

            int szum2 = 0;

            for (int i = 0; i < n; i++)
            {
                szum2 += arr[i];
            }

            int avg = szum2 / n;

            Console.WriteLine(szum);

            // 7 Buborékrendezés

            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int c = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = c;
                    }
                }
            }

            Console.WriteLine("\n\nRendezett Kiirás: ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

        }
    }
}
