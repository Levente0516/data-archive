using System.ComponentModel.Design;
using System.Diagnostics;

namespace Gyak03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tema;

            Console.WriteLine("Udvozollek a fugveny gyujtemenyben! \n\n" + "Adja meg a temakort: \n" + 
            "Geometria (1)\n" + "Kombinatorika (2)\n" + "Penzugy (3)\n" + "Masodfoku egyenlet (4)");
            int.TryParse(Console.ReadLine(), out tema);

            if (tema == 1)
            {
                int alakzat;
                Console.WriteLine("Adja meg az alakzatot: \n" + "Haromszog (1) \n" + "Negyzet (2) \n");
                int.TryParse(Console.ReadLine(), out alakzat);

                if (alakzat == 1)
                {
                    int harom_megoldasok;
                    Console.WriteLine("Adja meg mit akar kiszamolni: \n" + "Terulet: (1) \n" + "Kerulet: (2) \n");
                    int.TryParse(Console.ReadLine(), out harom_megoldasok);

                    if (harom_megoldasok == 1)
                    {
                        int harom_keplet;
                        Console.WriteLine("Adja meg mit tud: \n" + "Ossz. oldal hosszat: (1) \n" +
                        "2 oldalt es a kozbezart szoget: (2) \n");
                        int.TryParse(Console.ReadLine(), out harom_keplet);

                        if (harom_keplet == 1)
                        {
                            int heron_a, heron_b, heron_c, s;
                            Console.WriteLine("Adja meg az oldalak hosszat ilyen sorrendben: A, B, C \n");
                            int.TryParse(Console.ReadLine(), out heron_a);
                            int.TryParse(Console.ReadLine(), out heron_b);
                            int.TryParse(Console.ReadLine(), out heron_c);

                            s = (heron_a + heron_b + heron_c)/2;

                            Console.WriteLine("A haromszog terulete: {0}", (s*(s-heron_a)*(s-heron_b)*(s-heron_c)^(1/2)));
                        }
                    }
                }
            }

        }
    }
}