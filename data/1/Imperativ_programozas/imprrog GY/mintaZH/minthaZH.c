#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "mintazh.h"

int main()
{
    struct data *students = NULL;

    int option;
    int doo = 0;
    int id_num = 0;

    printf("Hi!\nThis is a student management system!\nChoose witch option would you like to do:\n\n");

    do
    {

        printf("1) - Add students\n2) - List students\n3) - Delete students\n4) - Save students\n5) - Load students\n6) - Find students\n7) - Update students\n8) - Exit\n\n");

        scanf("%d", &option);
        printf("\e[1;1H\e[2J");

        switch (option)
        {
            case 1:
                add_students(&students, &id_num);
                id_num++;
                break;
            case 2:
                list_students(students, id_num);
                break;
            case 3:
                del_students(&students, &id_num);
                id_num--;
                break;
            case 4:
                save_students(students, id_num);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                free_students(students, id_num);
                printf("Bye!\n");
                doo = 1;
                break;
            default:
                printf("Not an option\n");
                break;
        }

    } while (doo == 0);
    
    return 0;
}