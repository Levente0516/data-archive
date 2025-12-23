using System;
class Program
{

    /*
    Nagy Levente
    UJI470
    levente0517@gmail.com
    */

    public struct dolgozok
    {
        public int kor;
        public int fizetes;
        public dolgozok(int a, int b)
        {
            kor = a;
            fizetes = b;
        }
    }
    static void Main(string[] args)
    {
        int db = int.Parse(Console.ReadLine());

        int maxkor = 0;
        
        int maxindex = 0;

        dolgozok[] dolgozok_korido = new dolgozok[db];

        string[] temp = new string[db];

        for (int i = 0; i < db; i++)
        {
            temp = Console.ReadLine().Split(' ');

            dolgozok_korido[i] = new dolgozok(int.Parse(temp[0]), int.Parse(temp[1]));
        }

        for (int i = 0; i < db; i++)
        {
            if (dolgozok_korido[i].kor > maxkor)
            {
                maxkor = dolgozok_korido[i].kor;
                maxindex = i;
            }
        }

        Console.WriteLine(dolgozok_korido[maxindex].fizetes);
    }
}