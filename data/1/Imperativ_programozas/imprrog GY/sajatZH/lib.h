#ifndef _LIB_
#define _LIB_
#define SIZE 10

int tabel[SIZE][SIZE];

struct data
{
    char *nev;
    int x;
    int y;
};

void init_tabel(int tabel[SIZE][SIZE]);
void show_map(int tabel[SIZE][SIZE], int nincs);
void print_bus_stop(struct data *Busz, int busz_db, int nincs);
void create_bus_stop(struct data **Busz, int *busz_db, int tabel[SIZE][SIZE], int *nincs);
void delete_bus_stop(struct data **Busz, int *busz_db, int nincs, int tabel[SIZE][SIZE]);
void free_memory(struct data *Busz, int busz_db);

#endif