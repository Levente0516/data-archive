#include <stdio.h>
#include "tictaclib.h"
#include <string.h>

int main()
{
    init_tabel(table);
    print_tabel(table);

    int megy = 0;
    int x_or_o = 0; // 0 = o és 1 = x
    int nyert = 0;

    do
    {
        char buff[5];
        gets(buff);
        printf("\e[1;1H\e[2J");

        if (strcmp(buff, "EXIT") == 0)
        {
            megy++;
        }
        else
        {
            if (buff[0] == 'a' || buff[0] == 'b' || buff[0] == 'c')
            {
                if (buff[1] == '1' || buff[1] == '2' || buff[1] == '3')
                {
                    place(buff, &x_or_o, table);
                    win(table, &nyert);
                    if (nyert == 1)
                    {
                        megy++;
                    }
                }
                else
                {
                    printf("Rossz input\n");
                    print_tabel(table);
                }
            }
            else
            {
                printf("Rossz input\n");
                print_tabel(table);
            }
        }

    } while (megy == 0);
    
    return 0;
}