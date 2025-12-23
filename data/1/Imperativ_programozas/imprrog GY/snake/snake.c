#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>
#define a 12
#define b 22
#define c 9
#define d 2

void init_field(char tabla[a][b], int alma);
void init_snake(int kigyo[c][d]);
void print_game(char tabla[a][b], int kigyo[c][d]);
void update_snake(char tabla[a][b], int kigyo[c][d], char wasd);

int main()
{
    char tabla[a][b]; 
    int alma = 10, kigyo[c][d]; 

    init_field(tabla, alma);
    init_snake(kigyo);

    char wasd[100];
    printf("Szia!\nEbben ez a snake jatek\nMozgas:a-balra   s-lefele    w-felfele   d-jobbra\nKilepeshez irja be: EOF\n");
    print_game(tabla, kigyo);
    printf("Adja meg a lepeseket:");
    scanf("%s", &wasd);
    
    for(;;)
    {
        if (wasd[0] == 'E' && wasd[1] == 'O' && wasd[2] == 'F')
        {
            printf("Kilepes!\n");
            break;
        }
        else
        {
            for (int i = 0; i < strlen(wasd); i++)
            {
                if (wasd[i] == 'a')
                {
                    update_snake(tabla, kigyo, 'a');
                }
                else if (wasd[i] == 's')
                {
                    update_snake(tabla, kigyo, 's');
                }
                else if (wasd[i] == 'w')
                {
                    update_snake(tabla, kigyo, 'w');
                }
                else if (wasd[i] == 'd')
                {
                    update_snake(tabla, kigyo, 'd');
                }
                else
                {
                    continue;
                }
            }
        }
        print_game(tabla, kigyo);
        printf("Adja meg a lepeseket: ");
        scanf("%s", &wasd);
        printf("\n");
    } 

    return 0;
}

void init_field(char tabla[a][b], int alma)
{
    for (int t = 0; t < a; t++)
    {
        tabla[t][0] = '@';
    }
    for (int t = 0; t < b; t++)
    {
        tabla[0][t] = '@';
    }
    for (int t = 0; t < a; t++)
    {
        tabla[t][b-1] = '@';
    }
    for (int t = 0; t < b; t++)
    {
        tabla[a-1][t] = '@';
    }
    for (int i = 1; i < a-1; i++)
    {
        for (int t = 1; t < b-1; t++)
        {
            tabla[i][t] = ' ';
        }
    }

    srand(time(NULL));
    int randx = 0, randy = 0;

    for (int i = 0; i < alma; i++)
    {
        
        do
        {
            randx = rand() % a;
            randy = rand() % b;
        } while (tabla[randx][randy] == 'a' || tabla[randx][randy] == '@');
        tabla[randx][randy] = 'a';
    }
}

void init_snake(int kigyo[c][d])
{
    for (int i = 0; i < c+1; i++)
    {
        kigyo[i][0] = 1 + i;
        kigyo[i][1] = 1;
    }
}

void print_game(char tabla[a][b], int kigyo[c][d])
{
    char munka[a][b];
    for (int i = 0; i < a; i++)
    {
        for (int t = 0; t < b; t++)
        {
            munka[i][t] = tabla[i][t]; 
        }
    }

    for (int i = 1; i < c+1; i++)
    {
        int x = kigyo[i][0];
        int y = kigyo[i][1];

        if (i == 1)
        {
            munka[x][y] = '8';
        }
        else
        {
            munka[x][y] = '0';
        }
    }

    for (int i = 0; i < a; i++)
    {
        for (int t = 0; t < b; t++)
        {
            printf("%c", munka[i][t]);
        }
        printf("\n");
    }
}

void update_snake(char tabla[a][b], int kigyo[c][d], char wasd)
{
    if (wasd == 'a')
    {
        
    }
    else if (wasd == 's')
    {
        printf("S\n");
    }
    else if (wasd == 'w')
    {
        printf("W\n");
    }
    else if (wasd == 'd')
    {
        printf("D\n");
    }


}