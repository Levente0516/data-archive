#include <stdio.h>
#include <math.h>
int main()
{
    int N, osszeg = 0, hossz = 0;
    scanf("%d", &N);

    for (int i = 0; i < N+1; i++)
    {
        int temp = i;
        
        while (temp != 0)
        {
            hossz++;
            temp /= 10;
        }
        if (hossz == 0)
        {
            hossz = 1;
        }
        temp = i;
        for (int t = 0; t < hossz; t++)
        {
            int temp2 = temp % 10;
            osszeg = osszeg + pow(temp2, hossz);
            temp /= 10;
        }
        if (osszeg == i)
        {
            printf("%d\n", i);
        }

        hossz=0;
        osszeg=0;
    }
}