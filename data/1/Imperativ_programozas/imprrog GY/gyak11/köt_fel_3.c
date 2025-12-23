#include <stdio.h>

typedef struct 
    {
        double atlag;
        int kor;
        int azonosito;
    } Student;

int legjobb_diak(Student diakok[], int meret)
{
    Student max = diakok[0];
    for (int i = 1; i < meret; i++)
    {
        if (max.atlag < diakok[i].atlag)
        {
            max = diakok[i];
        }
    }

    return max.azonosito;
}

int main()
{
    Student diakok[] = 
    {
        {3.5, 19, 587212},
        {4.8, 21, 325438},
        {4.2, 18, 184523}
    };

    printf("A legmagasabb atlaggal rendelkezo diak azonostitoja: %d\n", legjobb_diak(diakok, 3));

    return 0;
}