using System.IO;
using TextFile;

namespace FiherContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organization org = new();

            try
            {
                TextFileReader reader = new("contest.txt");

                reader.ReadLine(out string line);
                char[] seperators = new char[] { ' ', '\t' };

                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                foreach(string fishername in tokens)
                {
                    org.Join(new Fisher(fishername));
                }

                while(reader.ReadLine(out string filename))
                {
                    TextFileReader reader1 = new(filename);

                    reader1.ReadLine(out line);
                    string[] conteststr = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    Contest contest = org.Organize(conteststr[0], DateTime.Parse(conteststr[1]));

                    reader1.ReadLine(out line);
                    string[] fishernames = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach(string fishername in fishernames)
                    {
                        contest.SignUp(org.Search(fishername));
                    }

                    while(reader1.ReadString(out string fishername))
                    {
                        reader1.ReadString(out string timestr);
                        DateTime time = DateTime.Parse(conteststr[1][0..11] + timestr);

                        reader1.ReadString(out string fishname);
                        reader1.ReadDouble(out double weight);

                        Fisher fisher = org.Search(fishername);

                        switch(fishname)
                        {
                            case "keszeg":
                                fisher.Catch(time, Bream.Instance(), weight, contest);
                                break;
                            case "ponty":
                                fisher.Catch(time, Carp.Instance(), weight, contest);
                                break;
                            case "harcsa":
                                fisher.Catch(time, Catfish.Instance(), weight, contest);
                                break;
                        }
                    }
                }

                if (org.BestContest(out Contest contest1))
                {
                    Console.WriteLine($"A legjobb verseny: {contest1.place}");
                }
                else
                {
                    Console.WriteLine("Nincs lyan verseny ahol mindenki fogott harcsát");
                }
            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("Hibás fájlnév");
            }
        }
    }
}
