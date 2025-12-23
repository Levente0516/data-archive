#include <stdio.h>
#include "box_lib.h"

int main()
{
    initialize();

    Push(1);
    Push(3);
    Push(2);

    printStack();

    Pop();

    printStack();

    copyTop();

    printStack();

    Push(1);
    Push(2);
    Push(3);

    printStack();

    while(!isEmpty())
    {
        Pop();
    }

    return 0;
}