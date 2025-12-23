#include <stdio.h>
#include <stdlib.h>

int main()
{
    for(;;)
    {
        char* pointer = (char*)malloc(sizeof(char)*10);
        fgets(pointer, sizeof(char)*10, stdin);
        
        printf("%c", pointer[0]);
    }
    
}