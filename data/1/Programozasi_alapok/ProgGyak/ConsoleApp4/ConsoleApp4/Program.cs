namespace Gyak03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int lakos;
            int kereset;
            int ossz_kereset = 0;
            Console.WriteLine("Hany Lakos van?: \n");
            int.TryParse(Console.ReadLine(), out lakos);

            int[] tomb =  new int[lakos];
            
            for (int i = 0; i < lakos; i++)
            {
                Console.WriteLine("Mennyi az {0}. lakos keresete \n", i + 1); 
                int.TryParse(Console.ReadLine(), out kereset);

                tomb[i] = kereset;

                ossz_kereset = ossz_kereset + kereset;
            }
             
            Console.WriteLine("Az osszes lako keresete: {0} \n", ossz_kereset);        

            //2

            int minimalber;
            Console.WriteLine("Adja meg a minimalbert: \n");
            int.TryParse(Console.ReadLine(), out minimalber);

            int keves = 0;

            for (int i = 0; i < lakos; i++)
            {
                if (tomb[i] < minimalber * 1.2)
                {
                    keves++;
                }
            }

            Console.WriteLine("{0}db lako keres keveset \n", keves);

            double kiraly_penz = 0;

            for (int i = 0; i < lakos; i++)
            {
                kiraly_penz = kiraly_penz + (tomb[i] * 0.7); 
            }

            Console.WriteLine("A kirlay penze: {0} \n", kiraly_penz);

            double max_index = 0;
            int sorszam = 0;

            for (int i = 0; i < lakos; i++)
            {
                if (tomb[i] >= max_index)
                {
                    max_index = tomb[i];
                    sorszam = i;
                }
            }

            Console.WriteLine("A legnagyobb kereset: {0}", max_index);
            Console.WriteLine("Es a sorszama: {0}", sorszam + 1);
        }   
    }
}
