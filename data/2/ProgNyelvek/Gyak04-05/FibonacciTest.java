// package time;

// You may copy these imports verbatim into your own tester code.
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;

import famous.sequence.Fibonacci;

public class FibonacciTest {
    @Test
    void testGetFib() {
        assertEquals(8, Fibonacci.fib(5));
    }

    @ParameterizedTest
    @CsvSource(textBlock = """
        8, 5
        13, 6
        21, 7
    """)
    void testEarlier(int expected, int n) {
        assertEquals(expected, Fibonacci.fib(n));
    }
}
