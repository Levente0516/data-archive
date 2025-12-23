using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Hunting
{
    class Hunter
    {
        public readonly string name;
        public readonly int age;
        public readonly List<Thropy> thropies = new();

        public Hunter(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Shot(Animal animal, string place, string date)
        {
            thropies.Add(new Thropy(animal, place, date));
        }

        public int CountMaleLions()
        {
            int c = 0;
            foreach (Thropy e in thropies)
            {
                if (e.animal.IsLion() && e.animal.gender == Animal.Gender.male)
                {
                    c++;
                }
            }
            return c;
        }

        public bool MaxHornWeigthRate(out double rate)
        {
            bool l = false;
            rate = 0.0;
            foreach(Thropy e in thropies)
            {
                if (!e.animal.IsRihno())
                {
                    continue;
                }
                Rihno rihno = e.animal as Rihno;
                double r = (double)rihno.Horn / rihno.weigth;
                if(!l)
                {
                    l = true;
                    rate = r;
                }
                else if (rate < r)
                {
                    rate = r;
                }
            }

            return l;
        }

        public bool SearchEqualTsuk()
        {
            foreach (Thropy e in thropies)
            {
                if ((e.animal is Elephant elephant) && elephant.Lefttuskk == elephant.Righttusk)
                {
                    return true;
                }
            }

            return false;
        }

        public void Read(string fname)
        {
            TextFileReader reader = new(fname);

            Animal animal = null;

            char[] seperators = new char[] { ' ', '\t' };

            while(reader.ReadLine(out string line))
            {
                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                string place = tokens[0];
                string date = tokens[1];
                string species = tokens[2];
                int weight = int.Parse(tokens[3]);
                Animal.Gender gender = (Animal.Gender)Enum.Parse(typeof(Animal.Gender), tokens[4]);

                switch(species)
                {
                    case "lion":
                        animal = new Lion(weight, gender);
                        break;
                    case "rihno":
                        int horn = int.Parse(tokens[5]);
                        animal = new Rihno(weight, horn, gender);
                        break;
                    case "elephant":
                        int lefttuskk = int.Parse(tokens[5]);
                        int righttusk = int.Parse(tokens[6]);
                        animal = new Elephant(weight, lefttuskk, righttusk, gender);
                        break;
                }

                Shot(animal, place, date);
            }
        }
    }
}
