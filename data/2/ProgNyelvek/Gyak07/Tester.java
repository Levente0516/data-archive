import text.to.numbers.MultiLineFile;

public class Tester 
{
    public static void main(String[] args) 
    {
        if (args.length == 0) 
        {
            System.out.println("Please provide a filename.");
            return;
        }
        try 
        {
            int result = MultiLineFile.addNumbers(args[0], ' ');
            System.out.println("Sum of numbers: " + result);
        } 
        catch (Exception e)
        {
            System.err.println("Error: " + e.getMessage());
        }
    }
}
