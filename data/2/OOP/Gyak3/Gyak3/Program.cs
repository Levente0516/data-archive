using TextFile;

namespace Gyak3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new("input.txt");

                Bag Bag = new();

                Console.WriteLine(Bag.ToString());

                while (reader.ReadString(out string elem))
                {
                    Bag.Insert(elem);
                    Console.WriteLine(Bag.ToString());
                }

                Console.WriteLine($"The most frequent element: {Bag.Max()}");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Input file does not exist");
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine("There is no msot frequented element in an empty bag.");
            }
        }
    }
}
