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
        union 
        {
            int kurzusok;
            double kreditindexek;
            double impakt;
        } extra;
        int erdos;
    } Student;

int main()
{
    return 0;
}