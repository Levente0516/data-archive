#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "mintazh.h"

void add_students(struct data **students, int *id_num)
{
    *students = realloc(*students, (*id_num + 1) * sizeof(struct data));

    struct data *newStudent = &(*students)[*id_num];
    newStudent->name = malloc(100); 
    newStudent->favsub = malloc(50);
    newStudent->date = malloc(100);

    newStudent->id = *id_num;

    printf("Adja meg a nevet:\n");
    while(getchar() != '\n');
    fgets(newStudent->name, 100, stdin);
    printf("Adja meg a korat:\n");
    scanf("%d", &newStudent->age);
    printf("Adja meg a szuletesi datumat:\n");
    while(getchar() != '\n');
    fgets(newStudent->date, 100, stdin);
    printf("Adja meg az atlagat:\n");
    scanf("%f", &newStudent->gpa);
    printf("Adjam meg a kedvenc tantargyat:\n");
    while(getchar() != '\n');
    fgets(newStudent->favsub, 50, stdin);

    newStudent->name[strcspn(newStudent->name, "\n")] = '\0';
    newStudent->date[strcspn(newStudent->date, "\n")] = '\0';  

    printf("Done!\n\n");

}

void list_students(struct data *students, int id_num)
{
    printf("-------------------------Student details-------------------------\nID\t\tNAME\tAGE\tDATE\t\tGPA\tFAVSUB\n");
    for (int i = 0; i < id_num; i++)
    {   
        printf("%d\t", students[i].id);
        printf("%s\t", students[i].name);
        printf("%d\t", students[i].age);
        printf("%s\t", students[i].date);
        printf("%.2f\t", students[i].gpa);
        printf("%s\n", students[i].favsub);
    }
}

void free_students(struct data *students, int id_num)
{
    for (int i = 0; i < id_num; i++)
    {
        free(students[i].name);
        free(students[i].favsub);
    }
    free(students);
}

void del_students(struct data **students, int *id_num)
{
    int deletable;
    printf("Witch student you want to delete?\n");
    scanf("%d", &deletable);

    free((*students)[deletable].name);
    free((*students)[deletable].date);
    free((*students)[deletable].favsub);

    for (int i = deletable; i < *id_num - 1; i++) 
    {
        (*students)[i] = (*students)[i + 1];
    }

    for (int i = deletable; i < *id_num - 1; i++) 
    {
        (*students)[i].id--;
    }

    *students = realloc(*students, (*id_num - 1) * sizeof(struct data));

    printf("DELETED\n\n");
}

void save_students(struct data *students, int id_num)
{
    char file_name[256];
    printf("Name of the file?\n");
    while(getchar() != '\n');
    fgets(file_name, 256, stdin);
    file_name[strcspn(file_name, "\n")] = '\0';

    strcat(file_name, ".txt");

    FILE *fp = fopen(file_name, "w");

    for (int i = 0; i < id_num; i++)
    {
        fprintf(fp, "%d ",students[i].id);
        fprintf(fp, "%s ",students[i].name);
        fprintf(fp, "%d ",students[i].age);
        fprintf(fp, "%s ",students[i].date);
        fprintf(fp, "%.2f ",students[i].gpa);
        fprintf(fp, "%s\n",students[i].favsub);
    }

    fclose(fp);

    printf("Saved\n\n");
}

void load_students()
{
    
}