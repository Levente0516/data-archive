module TicTacToe where

    data Player = X | O deriving Eq
    data Cell  = E | P Player deriving Eq
    data State = Running | GameOver (Maybe Player) deriving Eq

    type Size = Int
    type Board = [[Cell]]
    type Game = (Size, Board, Player, State)

    replaceAtMatrix :: (Int, Int) -> a -> [[a]] -> [[a]]
    replaceAtMatrix (x,y) char list = replaceAtMatrixHelper (x,y) list 0
        where
            replaceAtMatrixHelper (x,y) [] i = []
            replaceAtMatrixHelper (x,y) (z:zs) i
                | x >= length (z:zs) || y >= length z || x < 0 || y < 0 = z:zs
                | x == i = replaceAt y char z : zs
                | otherwise = z : replaceAtMatrixHelper (x,y) zs (i+1)

            replaceAt y char [] = []
            replaceAt y char (c:cs)
                | y == 0 = char : cs
                | otherwise = c : replaceAt (y-1) char cs