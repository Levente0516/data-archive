package text.to.numbers;
import java.io.*;

public class MultiLineFile
{
    public static int addNumbers(String filename, char c) throws Exception
    {
        int sum = 0;
        try(BufferedReader br = new BufferedReader(new FileReader(filename));)
        {
            String line;
            while((line = br.readLine()) != null)
            {
            
                String[] pieces = line.split(String.valueOf(c));

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
            }

            return sum; 

        } 
        catch(IOException ioe)
        {
            throw ioe;
        }
    }
}