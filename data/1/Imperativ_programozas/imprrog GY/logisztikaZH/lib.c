#include <stdio.h>
#include <stdlib.h>
#include "lib.h"

Raklap* create_pkg(int value)
{
    Raklap* newRaklap = (Raklap*)malloc(sizeof(Raklap));
    
    newRaklap->value = value;
    newRaklap->bal = NULL;
    newRaklap->jobb = NULL;

    return newRaklap;
}

int insert_pkg(Raklap** head, int value)
{
    Raklap* current = *head;

    current = current->jobb;
}

Raklap* create_pkg(int value);
