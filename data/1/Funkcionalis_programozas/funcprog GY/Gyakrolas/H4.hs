module H4 where

    mountain :: Integral i => i -> String
    mountain 0 = []
    mountain n = mountain (n-1) ++ replicate (fromIntegral n) '#' ++ "\n"

    countAChars :: Num i => String -> i
    countAChars [] = 0
    countAChars (x:xs)
        | x == 'a' = 1 + countAChars xs
        | otherwise = countAChars xs

    lucas :: (Integral a, Num b) => a -> b
    lucas 0 = 2
    lucas 1 = 1
    lucas n = lucas (n-2) + lucas (n-1)

    longerThan :: Integral i => [a] -> i -> Bool
    longerThan [] _ = False
    longerThan _ i | i <= 0 = True
    longerThan (_:xs) i = longerThan xs (i-1)

    format :: Integral i => i -> String -> String
    format 0 str = str
    format n [] = ' ' : format (n-1) []
    format n (x:xs) = x : format (n-1) xs

    merge :: [a] -> [a] -> [a]
    merge [] [] = []
    merge [] (x:xs) = x:xs
    merge (x:xs) [] = x:xs
    merge (x:xs) (y:ys) = x : y : merge xs ys 