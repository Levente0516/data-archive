namespace GYak02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a;

            Console.WriteLine("a = ");

            while (!(double.TryParse(Console.ReadLine(), out a)))
            {
                Console.WriteLine("a = ");
            }

            bool l = false;

            if (a % 2 == 0)
            {
                l = true;
            }

            Console.WriteLine("A szam paros-e?: {0}", l);

            double b;
            bool k = true;

            Console.WriteLine("B = ");

            while (!(double.TryParse(Console.ReadLine(), out b)))
            {
                Console.WriteLine("B = ");
            }

            for (int i = 2; i < (b / 2); i++)
            {
                if (b % i == 0)
                {
                    k = false;
                }
            }

            Console.WriteLine("Prim-e?: {0}", k);

            double x, y;

            Console.WriteLine("X = ");

            while (!(double.TryParse(Console.ReadLine(), out x)))
            {
                Console.WriteLine("X = ");
                
            }

            Console.WriteLine("Y = ");

            while (!(double.TryParse(Console.ReadLine(), out y)))
            {
                Console.WriteLine("Y = ");

            }

            if (x > 0)
            {
                if (y > 0)
                {
                    Console.WriteLine("Siknegyed: 1");
                }
                else
                {
                    Console.WriteLine("Siknegyed: 4");
                }
            }
            else
            {
                if (y > 0)
                {
                    Console.WriteLine("Siknegyed: 2");
                }
                else
                {
                    Console.WriteLine("Siknegyed: 3");
                }
            }
        }
    }
}
