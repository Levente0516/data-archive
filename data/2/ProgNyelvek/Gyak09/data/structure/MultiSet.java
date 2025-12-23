package data.structure;

import java.util.*;
import java.util.Map.Entry;

public class MultiSet<E>
{
    private HashMap<E, Integer> elemToCount;

    public MultiSet(E[] elements)
    {
        elemToCount = new HashMap<>();

        for (E element : elements)
        {
            if (elemToCount.containsKey(element))
            {
                elemToCount.put(element,1);
            }
            else
            {
                elemToCount.replace(element, elemToCount.get(element) + 1);
            }
        }
    }

    public int add(E elem)
    {
        if (elemToCount.containsKey(elem))
        {
            elemToCount.replace(elem, elemToCount.get(elem) + 1);
        }
        else
        {
            elemToCount.put(elem, 1);
        }

        return elemToCount.get(elem);
    }

    public int getCount(E elem)
    {
        if (elemToCount.containsKey(elem))
        {
            return elemToCount.get(elem);
        }
        
        return 0;
    }

    public MultiSet()
    {
        elemToCount = new HashMap<>();
    }

    public MultiSet<E> intersect(MultiSet<E> otherMultiSet)
    {
        MultiSet<E> alma = new MultiSet<>();

        for (Map.Entry<E, Integer> element : elemToCount.entrySet())
        {
            if (otherMultiSet.getCount(element.getKey()) > 0)
            {
                int min = Math.min(element.getValue(), otherMultiSet.getCount(element.getKey()));
                alma.elemToCount.put(element.getKey(), min);
            }
        }

        return alma;
    }

    public int size()
    {
        int i = 0;
        for (Map.Entry<E, Integer> element : elemToCount.entrySet())
        {
            i++;
        }

        return i;
    }
}