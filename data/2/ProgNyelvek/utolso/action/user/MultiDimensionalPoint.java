package action.user;
import action.*;

public class MultiDimensionalPoint implements Scalable, Undoable, Comparable<MultiDimensionalPoint>
{
    int[] cordinates;
    int[] lastCordinates;

    @Override
    public void undoLast()
    {
        int[] tmp = new int[cordinates.length];
        tmp = cordinates;
        cordinates = lastCordinates;
        lastCordinates = tmp; 
    }

    @Override
    public void scale(int factor)
    {
        lastCordinates = cordinates;
        for (int i = 0; i < cordinates.length; i++)
        {
            cordinates[i] *= factor;
        }
    }

    @Override
    public int compareTo(MultiDimensionalPoint o)
    {
        return 1;
    }
}