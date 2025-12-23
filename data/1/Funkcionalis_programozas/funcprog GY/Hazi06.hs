module Hazi06 where

    import Data.Char

    --1

    splitOn :: Eq a => a -> [a] -> [[a]]
    splitOn _ [] = [[]]
    splitOn n (x:xs) 
        | x == n = [] : splitOn n xs
        | otherwise = (x : head (splitOn n xs)) : tail (splitOn n xs)

    --2

    emptyLines :: Num a => String -> [a]
    emptyLines "" = [1]
    emptyLines x = emptyLinesHelper x 1 True
        where
            emptyLinesHelper [] n True = [n]
            emptyLinesHelper [] _ False = []
            --emptyLinesHelper ('\n':'\n':xs) n _ = n : emptyLinesHelper xs (n + 2) True
            emptyLinesHelper ('\n':'\n':'\n':xs) n _ = n : emptyLinesHelper xs (n + 1) True
            emptyLinesHelper ('\n':'\n':xs) n _ = n + 1 : emptyLinesHelper xs (n + 2) True
            emptyLinesHelper ('\n':xs) n _ = emptyLinesHelper xs (n+1) True
            emptyLinesHelper (_:xs) n _ = emptyLinesHelper xs n False

    --3

    csv :: String -> [[String]]
    csv [] = [[]]
    csv x = map (splitOn' ',') (splitOn' '\n' x) 
        where
            splitOn' :: Eq a => a -> [a] -> [[a]]
            splitOn' _ [] = [[]]
            splitOn' n (x:xs)
                | x == n = [] : splitOn' n xs
                | otherwise = (x : head (splitOn' n xs)) : tail (splitOn' n xs)