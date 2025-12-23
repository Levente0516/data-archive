#include <stdio.h>

int main()
{
    int c;

    while((c = getchar()) != EOF)
    {
        printf("%02x\n", (unsigned char)c);
    }
    return 0;
}