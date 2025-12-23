package textfile.lookup;
import java.io.*;

public class FileContent
{
    public static int numberOfLines(String filename, String words) throws Exception
    {
        int sum = 0;
        try(BufferedReader br = new BufferedReader(new FileReader(filename));)
        {
            String line;
            while((line = br.readLine()) != null)
            {
                String[] pieces = line.split(" ");

                for (String piece : pieces)
                {
                    try
                    {
                        if (piece == words)
                        {
                            sum++;
                        }
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

    public static int contentLineNumbers(String filename, String words) throws Exception
    {
        int sum = 0;
        int[] array;
        int arr_num = 0;
        try(BufferedReader br = new BufferedReader(new FileReader(filename));)
        {
            String line;
            while((line = br.readLine()) != null)
            {
                sum++;
                String[] pieces = line.split(" ");

                for (String piece : pieces)
                {
                    try
                    {
                        if (piece == words)
                        {
                            array[arr_num] = sum;
                            arr_num++;
                        }
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