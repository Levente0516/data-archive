using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiherContest
{
    public interface IFish
    {
        int Multiplier();
    }

        class Bream : IFish
        {
            private static Bream instance;

            private Bream() { }

            public static Bream Instance()
            {
                if (instance == null)
                {
                    instance = new Bream();
                }

                return instance;
            }

            public int Multiplier()
            {
                return 1;
            }
        }

        class Carp : IFish
        {
            private static Carp instance;

            private Carp() { }

            public static Carp Instance()
            {
                if(instance == null)
                {
                    instance = new Carp();
                }

                return instance;
            }

            public int Multiplier()
            {
                return 2;
            }
        }

        class Catfish : IFish
        {
            private static Catfish instance;
            private Catfish() { }

            public static Catfish Instance()
            {
                if (instance == null)
                {
                    instance = new Catfish();
                }

                return instance;
            }

            public int Multiplier()
            {
                return 3;
            }
        }
    
}
