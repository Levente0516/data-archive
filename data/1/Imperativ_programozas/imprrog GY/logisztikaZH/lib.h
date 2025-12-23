#ifndef _LIB_
#define _LIB_

typedef struct
{
    int value;
    struct Raklap* bal;
    struct Raklap* jobb;
} Raklap;

int insert_pkg();
void print_tree();
void list();
void earse();
void exit();

#endif