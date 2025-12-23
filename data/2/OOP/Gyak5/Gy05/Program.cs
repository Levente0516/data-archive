using System.Security.Cryptography.X509Certificates;
using TextFile;
namespace Gy05
{
    public class Program
    {
        static void Main(string[] args)
        {
            Counting("input.txt", out int countbegin, out int countend);
            Console.WriteLine($"Number of even numbers before first negative: {countbegin}");
            Console.WriteLine($"Number of even numbers after first negative: {countend}");
        }
        public static void Counting(string fname, out int countbegin, out int countend)
        {
            countbegin = 0;
            countend = 0;
            try
            {
                TextFileReader reader = new(fname);

                bool l = reader.ReadInt(out int e);
                while (l && e >= 0)
                {
                    if (e % 2 == 0) ++countbegin;
                    l = reader.ReadInt(out e);
                }
                while (l)
                {
                    if (e % 2 == 0) ++countend;
                    l = reader.ReadInt(out e);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not opened");
            }
        }
    }
}
