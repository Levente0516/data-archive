namespace ConsoleApp1
{
    internal class Program
    {

        //STRUKTÚRA
        public struct adat
        {
            public int adat_x; 
            public int adat_y;

            public adat (int x, int y)
            {
                adat_x = x;
                adat_y = y;
            }
        }
        static void Main(string[] args)
        {
            //BEOLVASÁS STRUCTBA SPLITTEl

            int db2 = 3;

            string[] temp = new string[db2];

            adat[] adatok = new adat[db2];

            for (int i = 0; i < db2; i++)
            {
                temp = Console.ReadLine().Split(' ');

                adatok[i] = new adat(int.Parse(temp[0]), int.Parse(temp[1]));
            }

            //KIIRATASA

            for (int i = 0; i < db2; i++)
            {
                Console.WriteLine(adatok[i].adat_x + " " + adatok[i].adat_y);
            }

            //MATRIX DEKLARALASA

            int[,] matrix = {{ 1, 2, 3 }, { 3, 2, 1 }, {-3, 5, 6}};

            //MATRIX KIIRATASA

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine(matrix[i, j]);
                }
            }

            //DEKRALÁLÁSOK 
            int db = 5;
            int[] nums = new int[db];
            nums = [1, 2, 3, 4, 5];

            Console.Write("SZAMOK: ");
            //KIIRATAS
            for (int i = 0; i < db; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
            //ÖSSZEGZÉS
            int osszeg = 0;
            for (int i = 0; i < db; i++)
            {
                osszeg += nums[i];
            }
            Console.WriteLine("OSSZEGZES: " + osszeg);

            //FELTÉTELES ÖSSZEGZÉS
            int feltosszeg = 0;
            for (int i = 0; i < db; i++)
            {
                if (nums[i] % 2 == 0) //PÁROS SZÁMOK
                {
                    feltosszeg += nums[i];
                }
            }
            Console.WriteLine("FELT OSSZEGZES: " + feltosszeg);

            //MEGSZÁMLÁLÁS
            int db_megszamlalas = 0;
            for (int i = 0; i < db; i++)
            {
                db_megszamlalas++;
            }
            Console.WriteLine("MEGSZAMLALAS: " + db_megszamlalas);

            //MAXIMUMKIVÁLASZTÁS
            int maxertek = nums[0];
            int maxindex = 0;
            for (int i = 1; i < db; i++)
            {
                if (nums[i] > maxertek)
                {
                    maxertek = nums[i];
                    maxindex = i;
                }
            }
            maxindex++;
            Console.WriteLine("MAX ES INDEX: " + maxertek + " " + maxindex);

            //FELTÉTELES MAXIMUM KERESÉS
            int feltmaxertek = nums[0];
            int feltmaxindex = 0;
            for (int i = 1; i < db; i++)
            {
                if (nums[i] > feltmaxertek && nums[i] % 2 == 0)
                {
                    feltmaxertek = nums[i];
                    feltmaxindex = i;
                }
            }
            feltmaxindex++;
            Console.WriteLine("FELT MAX ES FELT INDEX: " + feltmaxertek + " " + feltmaxindex);

            //ELDÖNTÉS
            bool van_e = false;
            for (int i = 0; i < db; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    van_e = true;
                    break;
                }
            }
            Console.WriteLine("ELDONTES: " + van_e);

            //OPTIMISTA ELDÖNTÉS
            int opt = 0;
            for (int i = 0; i < db; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    opt++;
                }
            }
            if(opt >= db)
            {
                Console.WriteLine("OPT ELDONTES: True");
            }
            else
            {
                Console.WriteLine("OPT ELDONTES: False");
            }

            //KIVÁLASZTÁS
            int megfelel = 0;
            bool megfelelt = true;
            for (int i = 0; i < db; i++)
            {
                if (nums[i] % 2 == 0 && megfelelt)
                {
                    megfelel = nums[i];
                    megfelelt = false; 
                }
            }
            Console.WriteLine("KIVALASZTAS: " + megfelel);

            //MÁSOLÁS
            int[] nums_masolt = new int[db];
            for (int i = 0; i < db; i++)
            {
                nums_masolt[i] = nums[i];
            }
            Console.Write("MASOLAS: ");
            for (int i = 0; i < db; i++)
            {
                Console.Write(nums_masolt[i] + " ");
            }

            //KIVÁLOGATÁS
            int[] kival = new int[db];
            for (int i = 0; i < db; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    kival[i] = nums[i];
                }
            }
            Console.Write("KIVALOGATAS: ");
            for (int i = 0; i < db; i++)
            {
                Console.Write(kival[i] + " ");
            }
        }
    }
}
