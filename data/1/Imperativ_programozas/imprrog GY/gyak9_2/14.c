#include <stdio.h>

int fuggveny ()
{
    static int x = 0;
    x++;
    printf("x: %d\n", x);
    return 0;
}

int main()
{
    fuggveny();
    fuggveny();
    fuggveny();

    return 0;
}