#include <stdio.h>
#include "my_utils.h"

int main()
{
    int a = 1;
    int b = 2;

    printf("nagyobb: %d\n", *nagyobb(&a, &b));
    swap(&a, &b);
    printf("a: %d, b: %d\n", a, b);
    printf("\nx(): %d\ny(): %d\n", x(), y());
    return 0;
}