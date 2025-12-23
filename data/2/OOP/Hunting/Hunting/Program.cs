namespace Hunting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hunter hunter = new("Zsolti", 63);
                hunter.Read("input.txt");

                Console.WriteLine($"Number of the male lions " + $"{hunter.CountMaleLions()}");

                if (hunter.MaxHornWeigthRate(out double rate))
                {
                    Console.WriteLine($"The most horn-weight " + $"rate among the rihnos: {rate:f3}");
                }
                else
                {
                    Console.WriteLine("There are no rihnos");
                }

                if (hunter.SearchEqualTsuk())
                {
                    Console.WriteLine("There exists an elephant" + " with same length tusks.");
                }
                else
                {
                    Console.WriteLine("There is no elephant" + " with same length tusks.");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Wrong file name");
            }
        }
    }
}
