#include <stdio.h>
#include <stdlib.h> //memóriafoglalás
#include <windows.h> //sleep

#define RESET "\033[0m"
#define BG_BLACK "\033[40m"
#define BG_RED "\033[41m"
#define BG_GREEN "\033[42m"
#define BG_YELLOW "\033[43m"
#define BG_BLUE "\033[44m"
#define BG_MAGENTA "\033[45m"
#define BG_CYAN "\033[46m"
#define BG_WHITE "\033[47m"

#define a 30

#define TERMINAL_CLEAR "\033[2J"
#define TERMINAL_HOME "\033[2H"

//felsoroló tipus
enum color
{
    BLACK, 
    RED,
    GREEN,
    YELLOW,
    BLUE,
    MAGENTA,
    CYAN,
    WHITE
};

//struct kép
struct image
    {
        int szelesseg; 
        int magassag;
        int **colorMatrix;
    }image;

//struct gif
struct gif
    {
        int szelesseg; 
        int magassag;
        int **colorMatrix;
    }gif[10];

void color_print (enum color szam);

int main()
{   
    //1
    //file megnyitása
    FILE *fp;

    fp = fopen("input.txt", "r");       // fájl megnyitása
    fscanf(fp, "%d", &image.szelesseg); // beolvasás
    fscanf(fp, "%d", &image.magassag);  // beolvasás

    //dinamikus memóriafoglalás
    image.colorMatrix = malloc(image.magassag * sizeof(int *));
    for (int i = 0; i < image.magassag; i++)
    {
        image.colorMatrix[i] = malloc(image.szelesseg * sizeof(int *));
    }

    //mátrix beolvasása
    for (int i = 0; i < image.magassag; i++)
    {
        for (int j = 0; j < image.szelesseg; j++)
        {
            fscanf(fp, "%d", &image.colorMatrix[i][j]);
        }
    }

    //fájl bezárása
    fclose(fp);

    //függvény meghívása
    for(int i = 0; i < image.magassag; i++)
    {
        for(int j = 0; j < image.szelesseg; j++)
        {
            color_print(image.colorMatrix[i][j]);
        }
        printf("\n");
    }

    //Memória felszabadítás
    for (int i = 0; i < image.magassag; i++)
    {
        free(image.colorMatrix[i]);
    }
    free(image.colorMatrix);

    //2
    //beolvasandó szöveg helyének deklarálása (alapméretezett max. file név hossza általában 255 karakter)
    char filename[256];
    char filename_full[260];

    printf("Adja meg a fajlnevet: ");
    scanf("%s", &filename);

    FILE *ft; //file megnyitása

    for (int i = 0; i < 10; i++)
    {
        sprintf(filename_full, "%s.bg%d", filename, i); //input -> input.bg0 | input.bg1 | input.bg2 ...

        ft = fopen(filename_full, "r");

        //csekkolás, hogy létezik e ilyen file
        if (ft == NULL)
        {
            printf("Ilyen file nem letezik!\n");
            return 1;
        }

        //paraméterek beolvasása
        fscanf(ft, "%d", &gif[i].szelesseg);
        fscanf(ft, "%d", &gif[i].magassag);

        //dinamikus memóriafoglalás
        gif[i].colorMatrix = malloc(gif[i].magassag * sizeof(int *));
        for (int j = 0; j < gif[i].magassag; j++)
        {
            gif[i].colorMatrix[j] = malloc(gif[i].szelesseg * sizeof(int *));
        }

        //beolvasás a mátrixba
        for (int z = 0; z < gif[i].magassag; z++)
        {
            for (int j = 0; j < gif[i].szelesseg; j++)
            {
                fscanf(ft, "%d", &gif[i].colorMatrix[z][j]);
            }
        }

        fclose(ft); //file bezárása
    }

    printf("%s%s",TERMINAL_CLEAR, TERMINAL_HOME); //képernyő letölrése az előző feladat után
    
    //függvény meghívása, képernyő törlése és a késleltetés
    for (int z = 0; z < 10; z++)
    {
        for (int i = 0; i < gif[z].magassag; i++)
        {
            for (int j = 0; j < gif[z].szelesseg; j++)
            {
                color_print(gif[z].colorMatrix[i][j]);
            }
            printf("\n");
        }
        Sleep(200);
        printf("%s%s",TERMINAL_CLEAR, TERMINAL_HOME);
    }

    //memória felszabadítása
    for (int z = 0; z < 10; z++)
    {
        for (int i = 0; i < gif[z].magassag; i++)
        {
            free(gif[z].colorMatrix[i]);
        }
        free(gif[z].colorMatrix);
    }

    return 0;
}

void color_print(enum color szam)
{
    switch (szam) 
    {
        case BLACK:
            printf("%s %s", BG_BLACK, RESET);
            break;
        case RED:
            printf("%s %s", BG_RED, RESET);
            break;
        case GREEN:
            printf("%s %s", BG_GREEN, RESET);
            break;
        case YELLOW:
            printf("%s %s", BG_YELLOW, RESET);
            break;
        case BLUE:
            printf("%s %s", BG_BLUE, RESET);
            break;
        case MAGENTA:
            printf("%s %s", BG_MAGENTA, RESET);
            break;
        case CYAN:
            printf("%s %s", BG_CYAN, RESET);
            break;
        case WHITE:
            printf("%s %s", BG_WHITE, RESET);
            break;
    }
}