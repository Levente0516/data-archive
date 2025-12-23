namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            string[] temp = Console.ReadLine().Split(' ');
            x = int.Parse(temp[0]);
            y = int.Parse(temp[1]);

            int[,] tomb = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                string[] temp2 = Console.ReadLine().Split(' ');
                for (int j = 0; j < y; j++)
                {
                    tomb[i,j] = int.Parse(temp2[j]);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(tomb[i, j] + " ");    
                }
                Console.WriteLine();
            }
            int[] sormaxok = new int[x];
            int[] oszlopmaxok = new int[y];

            for (int i = 0; i < x; i++)
            {
                sormaxok[i] = tomb[i, 0];
            }
            for (int i = 0; i < y; i++)
            {
                oszlopmaxok[i] = tomb[0, i];
            }
            for (int i = 0; i < x; i++)
            {
                int temp_max = sormaxok[i];
                for (int j = 0; j < y; j++)
                {
                    if (tomb[i,j] > temp_max)
                    {
                        temp_max = tomb[i,j];
                    }
                }
                sormaxok[i] = temp_max;
            }
            for (int i = 0; i < y; i++)
            {
                int temp_max = oszlopmaxok[i];
                for (int j = 0; j < x; j++)
                {
                    if (tomb[j, i] > temp_max)
                    {
                        temp_max = tomb[j, i];
                    }
                }
                oszlopmaxok[i] = temp_max;
            }
            Console.WriteLine();
            Console.WriteLine("Sormaxok:");
            for (int i = 0; i < x; i++)
            {
                Console.Write(sormaxok[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Oszlopmaxok:");
            for (int i = 0; i < y; i++)
            {
                Console.Write(oszlopmaxok[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
