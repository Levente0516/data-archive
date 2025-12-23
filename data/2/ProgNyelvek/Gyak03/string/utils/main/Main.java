package string.utils.main;

import string.utils.IterLetter.*;

public class Main
{
    public static void main(String[] args)
    {
        IterLetter IterLetter = new IterLetter(args[0]);

        for (int t = 0; t < args[1]; t++)
        {
            System.out.println(IterLetter.printNext());
        }
    }
} 