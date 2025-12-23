int *nagyobb(int *a, int *b)
{
    if (*a < *b)
    {
        return a;
    }
    else
    {
        return b;
    }
}

void swap(int *a, int *b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}

int x()
{
    return 5;
}
int y()
{
    return 3 * x();
}