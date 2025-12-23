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

int main()
{
    srand(time(NULL));
    Student *a = student_init(BSc);
    Student *b = student_init(Msc);

    printf("a:\natlag: %.2f, kor: %d, azonosito: %d, kurzusok: %d\n", a->atlag, a->kor, a->azonosito, a->extra.kurzusok);
    printf("b:\natlag: %.2f, kor: %d, azonosito: %d, impakt: %.f, erdos: %d\n", b->atlag, b->kor, b->azonosito, b->extra.impakt, b->erdos);

    free(a);
    free(b);

    return 0;
}