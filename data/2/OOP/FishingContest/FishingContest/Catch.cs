using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingContest
{
    public class Catch
    {
        public string datetime;
        public string species;
        public double length;
        public double weight;

        public Catch(string datetime, string species, double length, double weight)
        {
            this.datetime = datetime;
            this.species = species;   
            this.length = length;
            this.weight = weight;
        }
    }
}
