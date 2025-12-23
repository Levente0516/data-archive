module Hazi04 where

    --1

    mountain :: Integral i => i -> String
    mountain 0 = ""
    mountain x = (mountain (x - 1)) ++ replicate (fromIntegral x) '#' ++ "\n"

    --2

    countAChars :: Num i => String -> i
    countAChars [] = 0
    countAChars ('a':xs) = 1 + countAChars xs
    countAChars (_:xs) = countAChars xs

    --3

    lucas :: (Integral a, Num b) => a -> b
    lucas 0 = 2
    lucas 1 = 1
    lucas x = (lucas(x - 2)) + (lucas (x -1))

    --4

    longerThan :: Integral i => [a] -> i -> Bool
    longerThan [] _ = False
    longerThan _ n | n <= 0 = True
    longerThan (_:xs) n = longerThan xs (n - 1)
    

    --5

    format :: Integral i => i -> String -> String
    format 0 szoveg = szoveg
    format y [] = ' ' : format (y-1) []
    format y (x:xs) = x : format (y-1) xs

    --6

    merge :: [a] -> [a] -> [a]
    merge [] [] = []
    merge (x:xs) [] = x : xs
    merge [] (y:ys) = y: ys
    merge (x:xs) (y:ys) = x : y : merge (xs) (ys)