namespace ConsoleApp1
{
    internal class Program
    {
        public struct Adat
        {
            public int raktar_sorsza;
            public int uzlet_sorsza;
            public string azonosito;
            public int kiszall_db;
        }
        static void Main(string[] args)
        {
            int db, raktarak, uzletek;
            string aru;
            string[] temp = Console.ReadLine().Split(' ');


            db = int.Parse(temp[0]);
            raktarak = int.Parse(temp[1]);
            uzletek = int.Parse(temp[2]);
            aru = temp[3];

            Adat[] data = new Adat[db];

            for (int i = 0; i < db; i++)
            {
                string[] temp2 = Console.ReadLine().Split(' ');
                data[i].raktar_sorsza = int.Parse(temp2[0]);
                data[i].uzlet_sorsza =int.Parse(temp2[1]);
                data[i].azonosito = temp2[2];
                data[i].kiszall_db = int.Parse(temp2[3]);
            }

            //1
            int osszeg = 0;

            for (int i = 0; i < db; i++)
            {
                osszeg += data[i].kiszall_db;
            }
            Console.WriteLine("#");
            Console.WriteLine(osszeg);

            //2

            int[] fel2 = new int[raktarak];

            int max2 = 0;
            int index2 = 0;

            for (int i = 0; i < raktarak; i++)
            {
                for (int j = 0; j < db; j++)
                {
                    if (data[j].uzlet_sorsza == i)
                    {
                        fel2[i] = fel2[i] + data[j].kiszall_db;
                        
                    }
                }
                if (fel2[i] > max2)
                {
                    max2 = fel2[i];
                    index2 = i;
                }
            }
            Console.WriteLine("#");
            Console.WriteLine(index2 + " " + max2);

            //3

            int[] voltman = new int[raktarak];
            int voltman_db = 0;

            for (int i = 0; i < db; i++)
            {
                bool volt = true;
                if (data[i].azonosito == aru)
                {
                    for (int j = 0; j < voltman_db; j++)
                    {
                        if (data[i].uzlet_sorsza == voltman[j])
                        {
                            volt = false;
                        }
                    }
                    if(volt == true)
                    {
                        voltman[voltman_db] = data[i].uzlet_sorsza;
                        voltman_db++;
                    }
                }
            }
            Console.WriteLine("#");
            Console.WriteLine(voltman_db);

            //4

            string[] voltman2 = new string[raktarak];
            int voltman2_db = 0;

            for (int i = 0; i < db; i++)
            {
                bool volt2 = true;
                for (int j = 0; j < voltman2_db; j++)
                {
                    if (data[i].azonosito == voltman2[j])
                    {
                        volt2 = false;
                    }
                }
                if (volt2 == true)
                {
                    voltman2[voltman2_db] = data[i].azonosito;
                    voltman2_db++;
                }
            }

            Console.WriteLine("#");
            Console.WriteLine(voltman2_db);

            //5

            string[] voltman3 = new string[raktarak];
            int[] megoldasok = new int[raktarak];
            int megoldasok_db = 0;

            for (int i = 0; i < uzletek; i++)
            {
                int voltman3_db = 0;
                for (int j = 0; j < db; j++)
                {
                    bool volt3 = true;
                    if (data[j].uzlet_sorsza == i + 1)
                    {
                        for (int k = 0; k < voltman3_db; k++)
                        {
                            if (data[j].azonosito == voltman3[k])
                            {
                                volt3 = false; 
                            }
                        }
                        if (volt3 == true)
                        {
                            voltman3[voltman3_db] = data[j].azonosito;
                            voltman3_db++;
                        }
                    }
                }
                if (voltman3_db == 1)
                {
                    megoldasok[megoldasok_db] = i+1;
                    megoldasok_db++;
                }
            }
            Console.WriteLine("#");
            Console.Write(megoldasok_db);
            for (int i = 0; i < megoldasok_db; i++)
            {
                Console.Write(" " + megoldasok[i]);
            }
        }
    }
}
