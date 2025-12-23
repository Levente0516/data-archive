#include <stdio.h>

int k = 0;
int j = 0;

double a(double n)
{
    double r;

    r = n/2;
    k++;

    return r;
}

double b(double n)
{
    double r;

    r = n - 1;
    j++;

    return r; 
}

int main()
{

    double n;

    printf("Adjon meg egy szamot: \n");
    scanf("%lf", &n);

    while (n > 0)
    {
        n = a(n);

        if (n > 0){
            n = b(n);
        }
    }

    printf("A-B iteráció: %d - %d\n",k,j);

}