package string.utils;

public class IterLetter
{
    String letter;

    class IterLetter(String a)
    {
        if(a == null) {throw new IllegalArgumentException("null");}
        this.letter = a;
    }

    public int i = 0;

    public String printNext()
    {
        if (i != letter.length -1)
        {
        return letter[i];
        }
        else
        {
            return "";
        }
        i++; 
    }
}