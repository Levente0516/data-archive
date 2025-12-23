#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "lib.h"

void init_tabel(int tabel[SIZE][SIZE])
{
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            tabel[i][j] = -1;
        }
    }
}

void show_map(int tabel[SIZE][SIZE], int nincs)
{
    if (nincs == 1)
    {
        printf("Nincsenek megallok!\n");
    }
    else
    {
        printf("\n  ");
        for (int i = 0; i < SIZE; i++)
        {
            printf("%d ", i + 1);
        }
        printf("\n");
        for (int i = 0; i < SIZE; i++)
        {
            printf("%c", i + 97);
            for (int j = 0; j < SIZE; j++)
            {
                if (tabel[i][j] == 1)
                {
                    printf(" B");
                }
                else
                {
                    printf("  ");
                }
            }
            printf("\n");
        }
        printf("\n");
    }
}

void print_bus_stop(struct data *Busz, int busz_db, int nincs)
{   
    if (nincs == 1)
    {
        printf("Nincs meg megallo!\n");
    }
    else
    {
        for (int i = 0; i < busz_db; i++)
        {
            printf("%d. %s (%d, %d)\n", i+1, Busz[i].nev, Busz[i].x, Busz[i].y);
        }
    }
}

void create_bus_stop(struct data **Busz, int *busz_db, int tabel[SIZE][SIZE], int *nincs)
{
    *Busz = realloc(*Busz, (*busz_db + 1) * sizeof(struct data));

    struct data *NewBus = &(*Busz)[*busz_db];

    NewBus->nev = malloc(100);

    do
    {
        printf("Adja meg a buszmegallo nevet:\n");
        while (getchar() != '\n');
        fgets(NewBus->nev, 100, stdin);

        NewBus->nev[strcspn(NewBus->nev, "\n")] = '\0';

        printf("Adja meg az x kordinata:\n");
        while(NewBus->x <= 0 || NewBus->x >= 11)
        scanf("%d", &NewBus->x);

        char buff;
        printf("Adja meg az y kordinata (a-j):\n");
        while(buff < 'a' || buff > 'j')
        scanf(" %c", &buff);

        NewBus->y = buff - 'a';
    }while(tabel[NewBus->y][NewBus->x-1] != -1);

    tabel[NewBus->y][NewBus->x-1] = 1;

    printf("Megallo hozzadva!\n");  

    (*nincs) = 0;

    (*busz_db)++;
}

void delete_bus_stop(struct data **Busz, int *busz_db, int nincs, int tabel[SIZE][SIZE])
{
    if (nincs == 1)
    {
        printf("Nincs torolendo buszmegallo!\n");
    }
    else
    {
        int torolendo;
        printf("Adja meg a buszmegallo sorszamat amit torolni szeretne:\n");
        scanf("%d", &torolendo);

        tabel[(*Busz)[torolendo-1].y][(*Busz)[torolendo-1].x] == -1;

        free((*Busz)[torolendo-1].nev);

        for (int i = 0; i < *busz_db - 1; i++)
        {
            (*Busz)[i] = (*Busz)[i + 1];
        }

        *Busz = realloc(*Busz, (*busz_db - 1) * sizeof(struct data));

        (*busz_db)--;

        printf("Kitorolve!\n");
    }
}

void free_memory(struct data *Busz, int busz_db)
{
    for (int i = 0; i < busz_db; i++)
    {
        free(Busz[i].nev);
    }

    free(Busz);
}