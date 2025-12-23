package text.to.numbers;
import java.io.*;

public class SingleLineFile
{
    public static int addNumbers(String filename) throws Exception
    {
        int sum = 0;
        try(BufferedReader br = new BufferedReader(new FileReader(filename));)
        {
            String line = br.readLine();
            if (line == null)
            {
                throw new IllegalArgumentException("Empty file");
            }
            String[] pieces = line.split(" ");

            for(String piece : pieces)
            {
                try
                {
                    sum += Integer.parseInt(piece);
                }
                catch(NumberFormatException nfe)
                {
                    System.err.println("Could not be interpeted as an integer value");
                }
            }

            return sum;

        } 
        catch(IOException ioe)
        {
            throw ioe;
        }
    }
}