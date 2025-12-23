package array.util;

public class ArrayUtil
{
    public static int max(int[] array)
    {
        if(array.length == 0) {return 0;}

        int max = Integer.MIN_VALUE;

        for (int i = 0; i < array.length; i++)
        {
            max = array[i] > max ? array[i] : max;
        }

        return max;
    }

    public static int max2(int[] array)
    {
        if(array.length == 0) {return 0;}

        int max = Integer.MIN_VALUE;

        for (int element : array)
        {
            max = element > max ? element : max;
        }

        return max;
    }
}