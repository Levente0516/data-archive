import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.CheckThat;


public class ArrayUtilOwnTest
{
    int[] tomb = {1, 2, 3, 4 ,5};

    @Test
    public void maxLength0()
    {
        assertEquals(5, array.util.ArrayUtil.max(tomb));
    }
}