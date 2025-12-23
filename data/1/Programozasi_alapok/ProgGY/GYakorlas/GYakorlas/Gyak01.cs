namespace GYakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.WriteLine("A = ");
            double.TryParse(Console.ReadLine(), out a);

            Console.WriteLine("B = ");
            double.TryParse(Console.ReadLine(), out b);

            Console.WriteLine("C = ");
            double.TryParse(Console.ReadLine(), out c);

            double max_index = 0;

            for (int i = 0; i < 3; i++)
            {

                if (a > max_index)
                {
                    max_index = a;
                }
                if (b > max_index)
                {
                    max_index = b;
                }
                if (c > max_index)
                {
                    max_index = c;
                }
            }

            bool biz = true;
            bool derek = false;

            if (max_index == a)
            {
                if (b + c > max_index)
                {
                    biz = true;
                }
                else
                {
                    biz = false;
                }

                if ((b * b) + (c * c) == (max_index * max_index))
                {
                    derek = true;
                }

            }

            else if (max_index == b)
            {
                if (a + c > max_index)
                {
                    biz = true;
                }
                else
                {
                    biz = false;
                }

                if ((a * a) + (c * c) == (max_index * max_index))
                {
                    derek = true;
                }
            }

            else
            {
                if (a + b > max_index)
                {
                    biz = true;
                }
                else
                { 
                    biz = false; 
                }

                if ((a * a) + (b * b) == (max_index * max_index))
                {
                    derek = true;
                }
            }

            double s, heron;

            s = (a + b + c)/2;

            heron = s * (s-a) * (s-b) * (s-c);

            heron = Math.Sqrt(heron);

            Console.WriteLine("Lehet-e haromszog: {0}", biz);

            if (biz == true)
            {
                Console.WriteLine("Haromszog terulete: {0}", heron);
                Console.WriteLine("Haromszog kerulete: {0}", s * 2);
            }
            else
            {
                Console.WriteLine("Haromszog terulete: Nincs ilyen haromszog.");
                Console.WriteLine("Haromszog kerulete: Nincs ilyen haromszog.");
            }
            
            Console.WriteLine("Derekszogu-e?: {0}", derek);

        }
    }
}
