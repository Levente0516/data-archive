module H6 where

    splitOn :: Eq a => a -> [a] -> [[a]]
    splitOn n [] = [[]]
    splitOn n (x:xs)
        | x == n = [] : splitOn n xs
        | otherwise = (x : head (splitOn n xs)) : tail (splitOn n xs)

    emptyLines :: Num a => String -> [a]
    emptyLines "" = [1]
    emptyLines x = emptyLinesHelper x 1 True
        where
            emptyLinesHelper [] n True = [n]
            emptyLinesHelper [] _ False = []
            emptyLinesHelper ('\n':'\n':'\n':xs) n _ = n : emptyLinesHelper xs (n + 1) True
            emptyLinesHelper ('\n':'\n':xs) n _ = n + 1 : emptyLinesHelper xs (n + 2) True
            emptyLinesHelper ('\n':xs) n _ = emptyLinesHelper xs (n+1) True
            emptyLinesHelper (_:xs) n _ = emptyLinesHelper xs n False