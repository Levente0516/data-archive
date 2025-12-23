namespace Szekvencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double s, t;
            s = 60;
            t = 30;

            Console.WriteLine("A sebesseg: {0}", s/t);

            double ora, perc, masodperc;

            ora = 2;
            perc = 34;
            masodperc = 6;

            Console.WriteLine("Az ido masodpercekben: {0}", ora * 360 + perc * 60 + masodperc); 
        }
    }
}
