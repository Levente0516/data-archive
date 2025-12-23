namespace Gyak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Racionalis a = new Racionalis(3, -2);
                Racionalis b = new Racionalis(-20, 3);

                Console.WriteLine("a + b = {0}", a + b);
                Console.WriteLine("a - b = {0}", a - b);
                Console.WriteLine("a * b = {0}", a * b);
                Console.WriteLine("a / b = {0}", a / b);
            }
            catch (Racionalis.NullDenominator)
            {
                Console.WriteLine("Érvénytelen szám");
            }
            catch (Racionalis.NullDivision)
            {
                Console.WriteLine("Nullával való osztás");
            }
        }
    }
}
