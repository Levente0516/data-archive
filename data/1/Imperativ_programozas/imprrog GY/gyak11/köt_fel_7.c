#include <stdio.h>
#include <time.h>
#include <stdlib.h>

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

Student *student_init(Type type)
{
    Student *s = malloc(sizeof(Student));
    s->type = type;
    s->atlag = ((double)rand() / RAND_MAX) * 5;
    s->azonosito = rand() % 1000000;
    s->kor = rand() % 100;
    switch (type)
    {
        case BSc:
            s->extra.kurzusok = rand() % 70;
            break;
        case Msc:
            s->extra.kreditindexek = ((double)rand() / RAND_MAX) *5;
            break;
        case Phd:
            s->extra.impakt = ((double)rand() / RAND_MAX) *5;
            s->erdos = rand() % 50;
            break;
    }

    return s;
}

Student *legjobb_diak(Student** diakok, int meret)
{
    double max_atlag = diakok[0]->atlag;
    int maxind = 0;
    for (int i = 1; i < meret; i++)
    {
        printf("%f\t%f\n", max_atlag, diakok[i]->atlag);
        if (max_atlag < diakok[i]->atlag)
        {
            max_atlag = diakok[i]->atlag;
            maxind = i;
        }
    }

    printf("maxind: %d\n", maxind);

    Student *legjobb_atlagu_diak = diakok[maxind];

    return legjobb_atlagu_diak;
}

int main()
{
    srand(time(NULL));
    Student *diakok[10];
    for (int i = 0; i < 10; i++)
    {
        diakok[i] = student_init(rand() % 3 + 1);
        printf("a:\natlag: %.2f, kor: %d, azonosito: %d, kurzusok: %d\n",i, diakok[i]->azonosito,diakok[i]->atlag);

    }
    
    printf("legmagasabb atlaggal rendelkezo diak azonositoja: %d\n", legjobb_diak(diakok, 10)->azonosito);

    for (int i = 0; i< 10; i++)
    {
        free(diakok[i]);
    }

    return 0;
}