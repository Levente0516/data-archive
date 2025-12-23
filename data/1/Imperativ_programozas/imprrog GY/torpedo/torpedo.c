#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#define a 10

void init(int tabla[a][a]);
void printTable(int tabla[a][a]);
void submit(char x, char allas, int y, int tabla[a][a], int h);

int main()
{
    int tabla[a][a];

    init(tabla);
    printTable(tabla);

    for(;;)
    {
        static int h = 0;
        char x, allas;
        int y;
        scanf(" %c%d%c", &x, &y, &allas);

        if (x < 65 || x > 74 || y < 1 || y > 10 || (allas != '|' && allas != '_'))
        {
            continue;
        }
        x -= 65;
        submit(x, allas, y, tabla, h);
        if (h == 5)
        {
            break;
        }
        printTable(tabla);
    }

    return 0;
}

void init(int tabla[a][a])
{
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            tabla[i][j] = -2;
        }
    }
}

void printTable(int tabla[a][a])
{
    printf("   A B C D E F G H I J\n");
    for (int i = 0; i < a; i++)
    {
        printf("%2d ", i + 1);
        for (int j = 0; j < a; j++)
        {

            if (tabla[i][j] < 0)
            {
                printf("  ");
            }
            else
            {
                printf("%d ", tabla[i][j]);
            }
            
        }
        printf("\n");
    }
}

void submit(char x, char allas, int y, int tabla[a][a], int h)
{
    if (allas == '|')
    {
        for (int i = 0; i < h; i++)
        {
            if (tabla[x][y] != -2)
            {
                
            }
        }
    }
    
}