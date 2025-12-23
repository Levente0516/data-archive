#ifndef _LIB_
#define _LIB_
#define a 3

int table[a][a];

void init_tabel(int table[a][a]);
void print_tabel(int table[a][a]);
void place(char *buff, int *x_or_o, int table[a][a]);
void win(int table[a][a], int *nyert);

#endif