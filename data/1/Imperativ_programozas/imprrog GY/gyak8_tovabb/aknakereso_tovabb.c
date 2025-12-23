#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define a 10


void kirajzol(int tabla[a][a]);

void matrixInit(int tabla[a][a], int felfedett[a][a]);

void elhelyez(int tabla[a][a], int aknak);

void feltolt(int tabla[a][a]);

int main(int argc, char *argv[])
{
    int aknak = 5;
    int tabla[a][a], felfedett[a][a];

    if (argc < 2)
    {
        printf("Adja meg az aknak szamat: \n");
        return 0;
    }

    aknak = atoi(argv[1]);

    if (aknak < 3 || aknak > 30)
    {
        printf("Az aknak szamanak kisebbnek kell lenni mint 30 vagy nagyobbnak mint 3\n");
        return 0;
    }

        matrixInit(tabla,felfedett);
        kirajzol(tabla);
        elhelyez(tabla,aknak);
        feltolt(tabla);
        kirajzol(tabla);

    int felfedettek = 0, y;
    char x;

    system("clear");

    for(;;)
    {
        kirajzol(felfedett);
        scanf(" %c%d", &x, &y);
        system("clear");
        if (x < 65 || x > 74 || y < 0 || y > 9)
        {
            continue;
        }
        x -= 65;

        printf("Valasztott sor: %d, oszlop: %d, Aknak szama:%d\n", x, y, aknak);
        if (tabla[x][y] == -1)
        {
            printf("Felrobbant egy akna! Vesztettel\n");
            break;
        }
        else if (tabla[x][y] != felfedett[x][y])
        {
            felfedett[x][y] = tabla[x][y];
            felfedettek++;
            if(felfedettek == a * a - aknak)
            {
                printf("Megtalaltad az osszes aknat! Nyertel!\n");
                break;
            }
        }
    }

    return 0;
}

void elhelyez(int tabla[a][a], int aknak)
{
    srand(time(NULL));
    int randx = 0, randy = 0;
    for (int i = 0; i < aknak; i++)
    {
        do
        {
            randx = rand() % a;
            randy = rand() % a;
        }while (tabla[randx][randy] == -1);
        tabla[randx][randy] = -1;
    }
}

void matrixInit(int tabla[a][a], int felfedett[a][a])
{
    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            tabla[i][j] = -2;
            felfedett[i][j] = -2;   
        }
    }
}

void kirajzol(int tabla[a][a])
{
    printf("  0 1 2 3 4 5 6 7 8 9\n");
    for (int x = 0; x < a; x++)
    {
        printf("%c ", 65 + x);
        for(int y = 0; y < a; y++)
        {
            if (tabla[x][y] < 0)
            {
                printf("  ");
            }
            else
            {
                printf("%d ", tabla[x][y]);
            }
        }
        printf("\n");
    }
}

void feltolt(int tabla[a][a])
{
    for (int x = 0; x < a; x++)
    {
        for (int y = 0; y < a; y++)
        {
            if (tabla[x][y] == -2)
            {
                int s = 0;
                if (x > 0)
                {
                    if (tabla[x-1][y] == -1)
                    {
                        s++;
                    }
                    if (y > 0)
                    {
                        if (tabla[x-1][y-1] == -1)
                        {
                            s++;
                        }
                    }
                    if (y < a-1)
                    {
                        if (tabla[x-1][y+1] == -1)
                        {
                            s++;
                        }
                    }
                }
                if (x < a - 1)
                {
                    if(tabla[x+1][y] == -1)
                    {
                        s++;
                    }
                    if (y > 0)
                    {
                        if(tabla[x+1][y-1] == -1)
                        {
                            s++;
                        }
                    }
                    if (y < a-1)
                    {
                        if(tabla[x+1][y+1] == -1)
                        {
                            s++;
                        }
                    }
                    
                }
                if (y > 0)
                {
                    if (tabla[x][y-1] == -1)
                    {
                        s++;
                    }
                }
                if (y < a-1)
                {
                    if  (tabla[x][y+1] == -1)
                    {
                        s++;
                    }
                }
                tabla[x][y] = s;
            }
        }
    }
}