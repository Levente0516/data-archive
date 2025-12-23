#include <stdio.h>
#include <stdlib.h>
#define _SIZE_ 8

struct pieces
{
    int value;
    int x;
    int y;
    char name;
};

void show_board(char table[_SIZE_][_SIZE_]);
void init_pieces(struct pieces pieces[32]);
void init_board(struct pieces pieces[32], char table[_SIZE_][_SIZE_]);


int main()
{
    struct pieces pieces[32];
    char table[_SIZE_][_SIZE_];

    init_pieces(pieces);
    init_board(pieces, table);
    show_board(table);

    return 0;
}

void show_board(char table[_SIZE_][_SIZE_])
{
    for(int i = 0; i < _SIZE_; i++)
    {
        printf("%d ",i+1);
        for (int j = 0; j < _SIZE_; j++)
        {
            printf("%c ", table[i][j]);
        }
        printf("\n");
        if (i == _SIZE_-1)
        {
            printf("  ");
            for (int t = 65; t < _SIZE_ + 65; t++)
            {
                printf("%c ", t);
            }
        }
    }
}

void init_pieces(struct pieces pieces[32])
{
    int index = 0;

    for (int i = 0; i < _SIZE_; i++)
    {
        pieces[index++] = (struct pieces){1, 1, i, 'P'}; // White pawns
        pieces[index++] = (struct pieces){1, 6, i, 'p'}; // Black pawns
    }

    // Rooks
    pieces[index++] = (struct pieces){5, 0, 0, 'R'};
    pieces[index++] = (struct pieces){5, 0, 7, 'R'};
    pieces[index++] = (struct pieces){5, 7, 0, 'r'};
    pieces[index++] = (struct pieces){5, 7, 7, 'r'};

    // Knights
    pieces[index++] = (struct pieces){3, 0, 1, 'N'};
    pieces[index++] = (struct pieces){3, 0, 6, 'N'};
    pieces[index++] = (struct pieces){3, 7, 1, 'n'};
    pieces[index++] = (struct pieces){3, 7, 6, 'n'};

    // Bishops
    pieces[index++] = (struct pieces){3, 0, 2, 'B'};
    pieces[index++] = (struct pieces){3, 0, 5, 'B'};
    pieces[index++] = (struct pieces){3, 7, 2, 'b'};
    pieces[index++] = (struct pieces){3, 7, 5, 'b'};

    // Queens
    pieces[index++] = (struct pieces){9, 0, 3, 'Q'};
    pieces[index++] = (struct pieces){9, 7, 3, 'q'};

    // Kings
    pieces[index++] = (struct pieces){10, 0, 4, 'K'};
    pieces[index++] = (struct pieces){10, 7, 4, 'k'};
}

void init_board(struct pieces pieces[32], char table[_SIZE_][_SIZE_])
{
    for (int i = 0; i < _SIZE_; i++)
    {
        for (int j = 0; j < _SIZE_; j++)
        {
            table[i][j] = '.';
        }
    }

    for (int i = 0; i < 32; i++)
    {
        table[pieces[i].x][pieces[i].y] = pieces[i].name;
    }
}