#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "lib.h"

int main()
{
    printf("Szia!\nEz egy busz medezser\nMenupontok:\n\n");

    struct data *Busz = NULL;

    int running = 0;
    int x;
    int nincs = 1; // 1 alapbol
    int busz_db = 0;

    init_tabel(tabel);

    do
    {
        printf("1 - Terkep\n2 - Lista\n3 - Uj megallo\n4 - Megallo torlese\n5 - Mentes\n6 - Betoltes\n7 - Utvonal\n8 - Kilepes\n\n");

        scanf("%d", &x);

        switch (x)
        {
            case 1:
                show_map(tabel, nincs);
                break;
            case 2:
                print_bus_stop(Busz, busz_db, nincs);
                break;
            case 3:
                create_bus_stop(&Busz, &busz_db, tabel, &nincs);
                break;
            case 4:
                print_bus_stop(Busz, busz_db, nincs);
                delete_bus_stop(&Busz, &busz_db, nincs, tabel);
                break;
            case 5:
            
                break;
            case 6:
            
                break;
            case 7:
            
                break;
            case 8:
                printf("Viszlat!\n");
                free_memory(Busz, busz_db);
                running = 1;
                break;
            default:
                printf("Nincs ilyen menupont!\n");
                break;
        }

    } while (running == 0);
    
}