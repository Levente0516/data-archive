namespace Beadando_Labirynth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            string[] separatedLine = Console.ReadLine().Split();
            n = int.Parse(separatedLine[0]);
            m = int.Parse(separatedLine[1]);
            Labirynth.Content[,] map = new Labirynth.Content[n, m];
            Labirynth.Content placeholder;
            for (int i = 0; i < n; i++)
            {
                separatedLine = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    switch (separatedLine[j])
                    {
                        case "Üres":
                            placeholder = Labirynth.Content.EMPTY;
                            map[i, j] = placeholder;
                            break;
                        case "Fal":
                            placeholder = Labirynth.Content.WALL;
                            map[i, j] = placeholder;
                            break;
                        case "Kincs":
                            placeholder = Labirynth.Content.TREASURE;
                            map[i, j] = placeholder;
                            break;
                        case "Szellem":
                            placeholder = Labirynth.Content.GHOST;
                            map[i, j] = placeholder;
                            break;
                    }
                }
            }
            Labirynth labirynth = new Labirynth(map);
            int x, y;
            try
            {
                separatedLine = Console.ReadLine().Split();
                x = int.Parse(separatedLine[0]);
                y = int.Parse(separatedLine[1]);
                labirynth.Collect(x, y);
                Console.WriteLine("Sikerült begyűjteni");
            }
            catch (Exception e)
            {
                Console.WriteLine("Nem sikerült a begyűjtés");
            }
            try
            {
                separatedLine = Console.ReadLine().Split();
                x = int.Parse(separatedLine[0]);
                y = int.Parse(separatedLine[1]);
                Labirynth.Direction dir = new Labirynth.Direction(0, 0); ;
                separatedLine = Console.ReadLine().Split();
                dir.x = int.Parse(separatedLine[0]);
                dir.y = int.Parse(separatedLine[1]);
                Labirynth.Content result = labirynth.LookAt(x, y, dir);
                if (result == Labirynth.Content.TREASURE)
                    Console.WriteLine("Kincs");
                else if (result == Labirynth.Content.WALL)
                    Console.WriteLine("Fal");
                else if (result == Labirynth.Content.EMPTY)
                    Console.WriteLine("Üres");
                else
                    Console.WriteLine("Szellem");
            }
            catch (Exception e)
            {
                Console.WriteLine("Nem sikerült megtekinteni a tartalmat");
            }
        }
    }
}
