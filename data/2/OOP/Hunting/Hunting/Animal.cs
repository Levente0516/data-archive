using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunting
{
    abstract class Animal
    {
        public enum Gender
        {
            male,
            female
        };

        public readonly int weigth;

        public readonly Gender gender;

        protected Animal(int weigth, Gender gender)
        {
            this.weigth = weigth;
            this.gender = gender;
        }
        
        public virtual bool IsLion() { return false; }
        public virtual bool IsRihno() { return false; }
        public virtual bool IsElephant() {return false; }
    }

    class Elephant : Animal
    {
        public int Lefttuskk
        {
            get;
        }
        public int Righttusk
        {
            get;
        }

        public Elephant(int weigth, int ltusk, int rtusk, Gender gender) : base(weigth, gender)
        {
            Lefttuskk = ltusk;
            Righttusk = rtusk;
        }

        public override bool IsElephant() { return true; }
    }

    class Rihno : Animal
    {
        public int Horn
        {
            get;
        }

        public Rihno(int weigth, int horn, Gender gender) : base(weigth, gender)
        {
            Horn = horn;
        }

        public override bool IsRihno() { return true; }

    }

    class Lion : Animal
    {
        public Lion(int weigth, Gender gender) : base(weigth, gender)
        { 
        }

        public override bool IsLion() { return true; }
    }
}
