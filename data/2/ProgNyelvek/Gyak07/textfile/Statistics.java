package textfile;
import java.io.*;

public class Statistics
{
    public static int numberOfLines(String filename) throws Exception
    {
        int sum = 0;
        try(BufferedReader br = new BufferedReader(new FileReader(filename));)
        {
            String line;
            while((line = br.readLine()) != null)
            {
                sum++;   
            }

            return sum; 

        } 
        catch(IOException ioe)
        {
            throw ioe;
        }
    }

    public static int numberOfCharacters(String filename) throws Exception
    {
        int sum = 0;
        try(BufferedReader br = new BufferedReader(new FileReader(filename));)
        {
            String line;
            while((line = br.readLine()) != null)
            {
                String[] pieces = line.split("");

                for(String piece : pieces)
                {
                    try
                    {
                        sum++;
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