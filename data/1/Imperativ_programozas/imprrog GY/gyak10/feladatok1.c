#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char str [21];

    printf("Mqx 20 karakter hosszu szoveg: ");

    fgets(str,sizeof(str), stdin);
    int len = strlen(str);
    if(len > 0 && str[len-1] == '\n')
    {
        str[--len] = '\0';
    }

    char *masolat = malloc(sizeof(char) * (len + 1));

    for(int i = 0; i < len; i++)
    {
        masolat[i] = str[i];
    }

    masolat[len] = '\0';

    printf("masolat: %s, %d\n", masolat, len);

        free(masolat);

    return 0;
}