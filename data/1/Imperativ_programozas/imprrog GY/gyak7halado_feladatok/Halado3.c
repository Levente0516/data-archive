#include <stdio.h>

int main()
{
    int n, table[4][4];
    printf("Adjon meg egy szamot 1-töl 4-ig(balos, balos fejteton, jobbos, jobbos fejteton): \n");
    scanf("%d",&n);

    if (n == 1)
    {
        for (int i = 0; i < 4; i++)
        {
            for(int t = 1; t < i+2; t++)
            {
                printf("&"); 
            }
            printf("\n");
        }
    }
    else if (n == 2)
    {
        int temp = 4;
        for (int i = 0; i < 4; i++)
        {
            for(int t = temp; t > 0; t--)
            {
                printf("&"); 
            }
            temp--;
            printf("\n");
        }
    }
    else if (n == 3)
    {
        int temp = 3;
        for (int i = 0; i < 4; i++)
        {
            for(int t = temp; t > 0; t--)
            {
                printf(" "); 
            }
            for(int t = 1; t < i+2; t++)
            {
                printf("&"); 
            }
            temp--;
            printf("\n");
        }
    }
    else
    {
        int temp = 4;
        for (int i = 0; i < 4; i++)
        {
            for(int t = 0; t < i; t++)
            {
                printf(" "); 
            }
            for(int t = temp; t > 0; t--)
            {
                printf("&"); 
            }
            temp--;
            printf("\n");
        }
        
    }
}