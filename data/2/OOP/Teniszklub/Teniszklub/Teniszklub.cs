using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Teniszklub
{
    public class Teniszklub
    {
        public class PalyaNotFound : Exception { };
        public class TagNotFound : Exception { };
        public class DateDue : Exception { };
        public class PalyaFoglalt : Exception { };
        public class WrongTime : Exception { };

        public List<Palya> palya;
        public List<Tag> tag;
        public List<Foglalas> foglalas;

        public Teniszklub()
        {
            palya = new List<Palya>();
            tag = new List<Tag>();
            foglalas = new List<Foglalas>();
        }

        public void AddPalya(int sorszam, Enums.Palya_tipus tipus, bool fedett)
        {
            Palya newPalya = new Palya(sorszam, tipus, fedett, false);
            palya.Add(newPalya);
        }

        public void RemPalya(int sorszam)
        {
            bool l = true;
            for (int i = 0; i < palya.Count; i++)
            {
                if (palya[i].sorszam == sorszam)
                {
                    palya.RemoveAt(i);
                    l = false;
                }
            }

            if (l)
            {
                throw new PalyaNotFound();
            }
        }

        public void AddTag(string name, Enums.Jatekos_tipus tipus)
        {
            Tag newTag = new Tag(name, tipus);
            tag.Add(newTag);
        }

        public void RemoveTag(string name)
        {
            Tag tagToRemove = tag.Find(t => t.name == name);
            if (tagToRemove != null)
            {
                tag.Remove(tagToRemove);
            }
            else
            {
                throw new TagNotFound();
            }
        }

        public void foglalas_palya(Palya palya, Tag tag, DateTime date, int ido)
        {
            if (palya.foglalt)
            {
                throw new PalyaFoglalt();
            }
            if (ido < 6 && ido > 20)
            {
                throw new WrongTime();
            }
            Foglalas newFoglalas = new Foglalas(palya, tag, date, ido);
            palya.foglalt = true;
            foglalas.Add(newFoglalas);
        }

        public void lemondas(Palya palya, Tag tag, DateTime date, int ido, DateTime currdate)
        {
            bool found = false;
            var toRemove = new List<Foglalas>();

            foreach (var f in foglalas)
            {
                if (f.palya == palya && f.tag == tag && f.date.Date == date.Date && f.ido == ido)
                {
                    if (f.date > currdate)
                    {
                        toRemove.Add(f);
                        found = true;
                    }
                    else
                    {
                        throw new DateDue();
                    }
                }
            }

            foreach (var f in toRemove)
            {
                foglalas.Remove(f);
                palya.foglalt = false; 
            }

            if (!found)
            {
                throw new PalyaNotFound();
            }
        }
        public void ReadPalya(string fname)
        {
            TextFileReader reader = new TextFileReader(fname);

            char[] seperators = new char[] { ' ', '\t' };

            while (reader.ReadLine(out string line))
            {
                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                int sorszam = int.Parse(tokens[0]);

                Enums.Palya_tipus tipus = (Enums.Palya_tipus)Enum.Parse(typeof(Enums.Palya_tipus), tokens[1]);

                bool fedett;

                if (tokens[2] == "igen")
                {
                    fedett = true;
                }
                else
                {
                    fedett = false;
                }

                AddPalya(sorszam, tipus, fedett);
            }
        }

        public void ReadTag(string fname)
        {
            TextFileReader reader = new TextFileReader(fname);

            char[] seperators = new char[] { ' ', '\t' };

            while (reader.ReadLine(out string line))
            {
                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];

                Enums.Jatekos_tipus tipus = (Enums.Jatekos_tipus)Enum.Parse(typeof(Enums.Jatekos_tipus), tokens[1]);

                AddTag(name, tipus);
            }
        }
    }
}
