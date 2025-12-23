#include <stdio.h>

int *nagyobb(int *a, int *b)
{
    if (*a < *b)
    {
        return a;
    }
    else
    {
        return b;
    }
}

int main()
{
    int a = 20;
    int b = 30;
    printf("nagyobb = %p\n", nagyobb(&a, &b));
    return 0;
}