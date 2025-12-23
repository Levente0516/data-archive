#include <stdio.h>

int main()
{
    struct Student1
    {
        int kor;
        double atlag;
        int azonosito;
    };

    struct Student2
    {
        double atlag;
        int kor;
        int azonosito;
    };

    printf("1: %lu, 2: %lu\n", sizeof(struct Student1), sizeof(struct Student2));
}