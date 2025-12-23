using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace FishingContest
{
    class InFile
    {
        private readonly TextFileReader reader;

        public InFile(string fname)
        {
            reader = new TextFileReader(fname);
        }

        public Fisher Read()
        {
            Fisher fisher = null;
            if (reader.ReadLine(out string line))
            {
                char[] seperators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                fisher = new Fisher(tokens[0]);
                for(int i = 1; i < tokens.Length; i += 4)
                {
                    fisher.Add(new Catch(tokens[i], tokens[i+1], double.Parse(tokens[i+2]), double.Parse(tokens[i+3])));
                }

            }
            return fisher;
        }
    }
}
