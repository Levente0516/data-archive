namespace Gyak2_spiral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new(32, Notebook.Sort.lined);
            Console.WriteLine($"Type of notebook: {notebook.Type} ");
            Console.WriteLine($"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}");

            notebook.Write(1);
            Console.WriteLine($"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}");

            notebook.Remove(1);
            Console.WriteLine($"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}");

            bool l = notebook.Search(out int ind);
            if (l)
            {
                Console.WriteLine($"Found empty page: {ind}");
                notebook.Write(ind);
            }
            else
            {
                Console.WriteLine($"No empty pages");
            }
            Console.WriteLine($"Number of pages: {notebook.Count()}, Empty pages: {notebook.EmptyCount()}");
        }
    }
}
