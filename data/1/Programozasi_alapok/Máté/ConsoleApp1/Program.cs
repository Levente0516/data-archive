namespace ConsoleApp1
{
    internal class Program
    {
        public struct bemenet
        {
            public int telep_szam;
            public int napok_szam;
            public int korlat;

            public bemenet(int x, int y, int z)
            {
                telep_szam = x;
                napok_szam = y;
                korlat = z;
            }
        }
        static void Main(string[] args)
        {
            string adatok;

            adatok = Console.ReadLine();

            string[] darabok = adatok.Split(' ');

            int[] adat = new int[3];

            for (int i = 0; i < 3; i++)
            {                                    //adat[0] == települesek szama
                adat[i] = int.Parse(darabok[i]); //adat[1] == napok szama 
            }                                    //adat[2] == homerseklet korlat

            bemenet[,] cuccok = new bemenet[adat[0],adat[1]];


        }
    }
}
