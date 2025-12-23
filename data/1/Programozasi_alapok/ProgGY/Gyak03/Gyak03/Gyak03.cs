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

            // 3

            int j = 0;

            while (j < new && arr[j] <= 41) 
            {
                Console.Write(arr[j] + " ");
                j++;
            }

            // 4

            for (int i = 0; i < n; i++)
            {

            }
            
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

            Console.ReadLine();

            return 0;
        }
    }
}
