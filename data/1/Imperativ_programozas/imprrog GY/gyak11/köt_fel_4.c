#include <stdio.h>

typedef enum
{
    BSc,
    Msc,
    Phd
} Type;

typedef struct 
    {
        double atlag;
        int kor;
        int azonosito;
        Type type;
    } Student;

int main()
{
    return 0;
}