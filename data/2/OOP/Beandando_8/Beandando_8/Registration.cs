using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beandando_8
{
    abstract class Registration
    {
        public virtual int GetSize()
        {
            return 0;
        }
    }

    class File : Registration
    {
        private int size;

        public File(int szam)
        {
            size = szam;
        }

        public override int GetSize()
        {
            return size;
        }
    }

    class Folder : Registration
    {
        private List<Registration> items;
        public Folder()
        {
            items = new List<Registration>();
        }
        public override int GetSize()
        {
            int Tsize = 0;
            foreach (var item in items)
            {
                Tsize += item.GetSize();
            }

            return Tsize;
        }
        public void Add(Registration r)
        {
            items.Add(r);
        }

        public void Remove(Registration r)
        {
            items.Remove(r);
        }
    }

    class FileSystem : Folder
    {

    }
}
