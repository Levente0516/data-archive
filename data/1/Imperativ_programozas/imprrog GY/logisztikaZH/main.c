#include <stdio.h>
#include <stdlib.h>
#include "lib.h"

int main()
{

    Raklap* head = NULL;
    
    printf("Szia!\nEz a logisztikai felhasznalo felulet\nMenupontok:\n\n");

    int running = 0;
    int x;

    do
    {
        printf("1 - Hozzadas\n2 - Kirajzolas\n3 - Lista\n4 - Csomag torlese\n5 - Kilepes\n\n");
        scanf("%d", &x);

        switch (x)
        {
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            running = 1;
            printf("Viszlat!\n");
            break;
        default:
            printf("Nincs ilyen menupont!\n");
            break;
        }

    } while (running == 0);
    
}