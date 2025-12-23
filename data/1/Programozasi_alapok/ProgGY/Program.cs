namespace _24_25_prog_n11_gy1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Szöveg kiírása a parancssoros felületre:
            //
            //   Console.WriteLine();
            //   Console.Write();
            // 
            // A fönti utasítások a 'Console' osztály 'WriteLine' vagy 'Write' metódusait hívják meg.
            // Ezekkel a fogalmakkal egyelőre mélyebben nem foglalkozunk!
            // 
            // A zárójelek közé a metódus ún. paraméterei kerülnek, egy metódushoz többféle
            // paraméterezés is tartozhat. A paraméter valamilyen bemenő adat, amellyel a metódus
            // dolgozik.
            //
            // Kísérletezzünk:
            // > írjuk ki, hogy "Hello World".
            // > Írjuk ki, hogy ""Hello World"", tehát ezúttal a szöveg idézőjelek között jelenjen meg.
            // > Írjuk ki, hogy "ELTE INFORMATIKAI KAR", ám minden szó kerüljön új sorba. Egy utasítást
            //   használjunk.

            // Kód:




            // --- Általátunk használt primitív változótípusok
            // 
            //   egész szám: int
            //   egész szám 64 biten: long
            //   lebegőpontos szám: float
            //   lebegőpontos szám 64 biten: double
            //   karakter: char
            //   szöveg: string
            //   logikai: bool
            //
            // Deklaráció:
            //   típus azonosító;
            // Pl.:
            //   int age;
            //
            // Inicializációval:
            //   típus azonosító = érték;
            // Pl.:
            //   int age = 33;
            //
            // --- Néhány konverzió:
            // 
            // Convert osztály metódusai (kísérlezett), pl.:
            //   Convert.ToInt32();
            //   Convert.ToString();
            // stb.
            //
            // Szöveg parsing:
            //   int.Parse();
            //   double.Parse();
            // stb.

            // Kód:




            // --- Tömbök
            //
            // Valamilyen típusú tömb:
            //   típus[]
            // Pl.:
            //   int[]
            //
            // Deklaráció és default inicializáció:
            //   típus[] azonosító = new típus[hossz];
            // Pl.:
            //   int[] numbers = new int[5];
            //
            // Létrehozható tömb kezdeti értékekkel, így:
            //   int[] numbers = {4,3,5,6,2};
            //
            // Tömb elemének elérése (indexeléssel):
            //   azonosító[sorszám]
            // Pl.:
            //   numbers[2]
            //
            // Mindig 0-tól indexelünk, így az első elemet a 0. indexen érjük el.
            // 
            // Tömbhossz:
            // azonosító.Length;

            // Kód:




            // --- Elágazások
            //
            //   if (feltétel)
            //      {
            //          ha igaz
            //      {
            //
            //
            //   if (feltétel)
            //      {
            //          ha igaz
            //      {
            //   else
            //      {
            //          ha nem igaz
            //      }
            //
            //
            //   switch(adat)
            //      {
            //          case érték:
            //              valami
            //              break;
            //
            //          case érték:
            //              valami
            //              break;
            //
            //          deault:
            //              valami;
            //              break;
            //      }

            // Kódom:




            // --- Ciklusok
            //
            //   for (indexváltozó = érték; futási_feltétel; indexáltozó manipulációja)
            //      {
            //          valami
            //      }
            //
            //
            //   while (futási_feltétel)
            //      {
            //          valami
            //      }
            //
            //
            //   foreach (valami in adatszerkezet)
            //      {
            //          valami
            //      }

            // Kód:


        }
    }
}