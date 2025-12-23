#ifndef _MINTAZH_
#define _MINTAZH_

struct data
{
    int id;
    char *name;
    int age;
    char *date;
    float gpa;
    char *favsub;
};

void add_students(struct data **students, int *id_num);
void list_students(struct data *students, int id_num);
void del_students(struct data **students, int *id_num);
void save_students(struct data *students, int id_num);
void load_students();
void find_students();
void update_students();
void free_students(struct data *students, int id_num);

#endif