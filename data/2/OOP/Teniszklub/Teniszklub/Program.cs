using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teniszklub
{
    public class Program
    { 
        public class TagNotFound : Exception { };

        private static Teniszklub klub;
        static void Main(string[] args)
        {
            try
            {
                klub = new Teniszklub();
                klub.ReadPalya("Palyak.txt");
                klub.ReadTag("Tagok.txt");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            //a
            try
            {
                Console.WriteLine("Adja meg a pálya tipusát: ");
                string a = Console.ReadLine();
                Enums.Palya_tipus tipus = (Enums.Palya_tipus)Enum.Parse(typeof(Enums.Palya_tipus), a);
                List<Palya> matching = FeltSearchPalya(klub, tipus);

                foreach (var p in matching)
                {
                    Console.WriteLine($"Sorszam {p.sorszam}, Típus: {p.tipus}, Fedett: {p.fedett}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Nem létezik ilyen tipusú pálya");
            }

            //b

            //elsőnek foglaljunk egy pályát
            Palya palya1 = klub.palya.First(p => p.sorszam == 1);
            Tag bence = klub.tag.Find(p => p.name == "Bence");
            DateTime date_foglalas = new DateTime(2026, 04, 12);
            bence.Palya_foglalas(klub, palya1, date_foglalas, 10);

            //Keresés
            try
            {
                Console.WriteLine("Adja meg a tag nevét: ");
                string name = Console.ReadLine();
                Tag tag = klub.tag.Find(t => t.name == name);

                if (tag == null)
                {
                    throw new TagNotFound();
                }

                Console.WriteLine("Adja meg a dátumot (éééé,. hh. nn. formátumban pl.: 2025.04.12)");
                DateTime date = DateTime.Parse(Console.ReadLine());

                List<Foglalas> foglalasok = FeltSearchFoglalasok(klub, tag, date);
                if (foglalasok.Count != 0)
                {
                    foreach (var p in foglalasok)
                    {
                        Console.WriteLine($"Pálya: {p.palya.sorszam}, Típus: {p.palya.tipus}, Fedett: {p.palya.fedett}, Idő: {p.ido}:00");
                    }
                }
                else
                {
                    Console.WriteLine("Nem történt foglalás");
                }
            }
            catch (FormatException es)
            {
                Console.WriteLine(es.Message);
            }

            //c
            try
            {
                Console.WriteLine("Adjon meg egy tagot: ");
                string name_c = Console.ReadLine();
                Tag tag_c = klub.tag.Find(t => t.name == name_c);

                if (tag_c == null)
                {
                    throw new TagNotFound();
                }

                Console.WriteLine("Adja meg a dátumot (éééé,. hh. nn. formátumban pl.: 2025.04.12)");
                DateTime date_c = DateTime.Parse(Console.ReadLine());

                double fizetes = Mennyibe(klub, tag_c, date_c);

                Console.WriteLine($"{name_c} ennyit fizetett {date_c.ToShortDateString()} napra: {fizetes}");
            }
            catch (FormatException es)
            {
                Console.WriteLine(es.Message);
            }

            //d
            try
            {
                Console.WriteLine("Adja meg a kezdő dátumot amely között a bevételt keresi: ");
                DateTime date_kezdo = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Adja meg a végső dátumot amely között a bevételt keresi: ");
                DateTime date_vegso = DateTime.Parse(Console.ReadLine());

                double bevetel = Klub_bevetel(klub, date_kezdo, date_vegso);

                Console.WriteLine($"A klub bevétele {date_kezdo.ToShortDateString()} és {date_vegso.ToShortDateString()} között {bevetel} volt");
            }
            catch (FormatException es)
            {
                Console.WriteLine(es.Message);
            }

            //foglalás visszamondása
            bence.Palya_lemondas(klub, palya1, date_foglalas , 10, DateTime.Now);
        }

        public static List<Palya> FeltSearchPalya(Teniszklub klub, Enums.Palya_tipus tipus)
        {
            List<Palya> palyas = new List<Palya>();

            foreach(var p in klub.palya)
            {
                if (p.tipus == tipus && !p.foglalt)
                {
                    palyas.Add(p);
                }
            }

            return palyas;
        }

        public static List<Foglalas> FeltSearchFoglalasok(Teniszklub klub, Tag tag, DateTime date)
        {
            List<Foglalas> matching = new List<Foglalas>();

            foreach(var p in klub.foglalas)
            {
                if (p.tag.name == tag.name && p.date.Date == date)
                {
                    matching.Add(p);
                }
            }

            return matching;
        }

        public static double Mennyibe(Teniszklub klub, Tag tag, DateTime date)
        {
            double osszesen = 0;
            double szorzo = 1;
            double fedette = 1;

            foreach(var p in klub.foglalas)
            {
                if (p.tag.name == tag.name && p.date.Date == date.Date)
                {
                    switch(p.tag.tipus)
                    {
                        case Enums.Jatekos_tipus.nyugdijas:
                            szorzo = 0.6; // Nyugdíjas kap 40% kedvezményt
                            break;
                        case Enums.Jatekos_tipus.igazolt_sportolo:
                            szorzo = 0.7; // igazolt sportolo 30% kedvezmenyt kap
                            break;
                        case Enums.Jatekos_tipus.diak:
                            szorzo = 0.8; // diak 20%-ot
                            break;
                    }

                    if (p.palya.fedett)
                    {
                        fedette = 1.2; //20% felar ha fedett
                    }
                    else
                    {
                        fedette = 1;
                    }

                    switch(p.palya.tipus)
                    {
                        case Enums.Palya_tipus.fu:
                            osszesen += 5000 * szorzo * fedette;
                            break;
                        case Enums.Palya_tipus.muanyag:
                            osszesen += 2000 * szorzo * fedette;
                            break;
                        case Enums.Palya_tipus.salak:
                            osszesen += 3000 * szorzo * fedette;
                            break;
                    }
                }
            }

            return osszesen;
        }

        public static double Klub_bevetel(Teniszklub klub, DateTime date_kezdo, DateTime date_vegso)
        {
            double osszesen = 0;
            double szorzo = 1;
            double fedette = 1;

            foreach (var p in klub.foglalas)
            {
                if (p.date > date_kezdo && p.date < date_vegso)
                {
                    switch (p.tag.tipus)
                    {
                        case Enums.Jatekos_tipus.nyugdijas:
                            szorzo = 0.6; // Nyugdíjas kap 40% kedvezményt
                            break;
                        case Enums.Jatekos_tipus.igazolt_sportolo:
                            szorzo = 0.7; // igazolt sportolo 30% kedvezmenyt kap
                            break;
                        case Enums.Jatekos_tipus.diak:
                            szorzo = 0.8; // diak 20%-ot
                            break;
                    }

                    if (p.palya.fedett)
                    {
                        fedette = 1.2; //20% felar ha fedett
                    }
                    else
                    {
                        fedette = 1;
                    }

                    switch (p.palya.tipus)
                    {
                        case Enums.Palya_tipus.fu:
                            osszesen += 5000 * szorzo * fedette;
                            break;
                        case Enums.Palya_tipus.muanyag:
                            osszesen += 2000 * szorzo * fedette;
                            break;
                        case Enums.Palya_tipus.salak:
                            osszesen += 3000 * szorzo * fedette;
                            break;
                    }
                }
            }

            return osszesen;
        }
    }
}