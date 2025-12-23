package data.structure;

import java.util.Map.Entry;
import java.util.*;

public class ListUtil
{
    public static ArrayList<Integer> divisors(int a)
    {
        ArrayList<Integer> osztok = new ArrayList<>();

        for (int i = 1; i < a/2; i++)
        {
            if (a % i == 0)
            {
                osztok.add(i);
            }
        }

        return osztok;
    }

    public static ArrayList<String> withSameStartEnd(ArrayList<String> s)
    {
        ArrayList<String> jo = new ArrayList<>();

        for (String ss : s)
        {
            if (ss != null && !ss.isEmpty() && ss.charAt(0) == ss.charAt(ss.length() - 1))
            {
                jo.add(ss);
            }
        }

        return jo;
    }

    public static void maxToFront(ArrayList<String> s)
    {
        if (s.isEmpty() && s == null)
        {
        }

        char max = 'A';
        int maxindex = 0;
        int i = 0;

        for (String ss : s)
        {
            if (ss.charAt(0) >= max)
            {
                max = ss.charAt(0);
                maxindex = i;
                i++;
            }
        }

        s.add(0,s.get(i));
        s.remove(s.get(i+1));
    }
}