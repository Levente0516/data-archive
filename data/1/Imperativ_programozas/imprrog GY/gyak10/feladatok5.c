#include <stdio.h>
#include <stdlib.h>
#define b 100

int main(int argc, char * argv[])
{
    if (argc < 2)
    {
        printf("hany szot szeretnel beolvasni?\n");
        return 0;
    }

    int a = atoi(argv[1]);
    char **szavak = malloc(sizeof(char *) * a);
    for (int i = 0; i < a; i++)
    {
        szavak[i] = malloc(sizeof(char) * b);
        printf("%d. szo: ", i + 1);
        fgets(szavak[i], b-1, stdin);
    }

    for(int i = a -1; i >= 0; i--)
    {
        printf("%s\n", szavak[i]);
        free(szavak[i]);
    }

    free(szavak);
    return 0;
} 