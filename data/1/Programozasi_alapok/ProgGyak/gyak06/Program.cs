internal class Program
{

    public struct butorok
    {
        public double ar;
        public double kor;

        public butorok(double a, double b)
        {
            ar = a;
            kor = b;
        }
    }
    static void Main(string[] args)
    {
        int db = int.Parse(Console.ReadLine());

        butorok[] ar_kor = new butorok[db];
        string[] temp;

        for (int i = 0; i < db; i ++)
        {
            temp = Console.ReadLine().Split();

            ar_kor[i] = new butorok(double.Parse(temp[0]), double.Parse(temp[1])); 
        }

        double[] uj_arak = new double[db];

        for (int i = 0; i < db; i++)
        {
            uj_arak[i] = ar_kor[i].ar - (ar_kor[i].ar * (2024 - ar_kor[i].kor)*0.01);
        }

        for (int i = 0; i < db; i++)
        {
            Console.WriteLine(uj_arak[i]);
            Console.WriteLine("\n");
        }
    }
}