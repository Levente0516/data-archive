#include <stdio.h>
#include "tictaclib.h"
#define a 3

void init_tabel(int table[a][a])
{
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            table[i][j] = -5;
        }
    }
}

void print_tabel(int table[a][a])
{
    printf("  a b c\n");
    int i;
    for (i = 0; i < a; i++)
    {   
        printf("%d ", i + 1);
        for (int j = 0; j < a; j++)
        {
            if (table[i][j] == 0)
            {
                printf("O ");
            }
            else if (table[i][j] == 2)
            {
                printf("X ");
            }
            else
            {
                printf("  ");
            }
        }
        printf("\n");
    }
}

void place(char *buff, int *x_or_o, int table[a][a])
{
    int x = (buff[0] == 'a') ? 0 : (buff[0] == 'b') ? 1 : 2;
    int y = buff[1] - '1';


    if (table[y][x] != -5)
    {
        printf("Mar foglalt!\n");
        print_tabel(table);
    }
    else
    {
        if (*x_or_o == 0)
        {
            table[y][x] = 0;
            print_tabel(table);
            *x_or_o = 1;
        }
        else
        {
            table[y][x] = 2;
            print_tabel(table);
            *x_or_o = 0;
        }
    }
}

void win(int table[a][a], int *nyert)
{
    int osszeg = 0;
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            osszeg = osszeg + table[i][j];
        }
        if (osszeg == 0 || osszeg == 6)
        {
            printf("Nyertel!\n");
            *nyert = 1;
        }
        osszeg = 0;
    }
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            osszeg = osszeg + table[j][i];
        }
        if (osszeg == 0 || osszeg == 6)
        {
            printf("Nyertel!\n");
            *nyert = 1;
        }
        osszeg = 0;
    }
    if ((table[0][0] == 0 && table[1][1] == 0 && table[2][2] == 0) || (table[0][2] == 2 && table[1][1] == 2 && table[2][0] == 2) || (table[0][0] == 2 && table[1][1] == 2 && table[2][2] == 2) ||  (table[0][2] == 0 && table[1][1] == 0 && table[2][0] == 0))
    {
        printf("Nyertel!\n");
        *nyert = 1;
    }
}