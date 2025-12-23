module Vizsgaaa where

    import Data.Char
    import Data.Maybe

    threeDivs:: Integral a => (a,a) -> (a,a) -> (a,a) -> Maybe a
    threeDivs (x,y)(u,v)(l,k)
        | y == 0 || v == 0 || k == 0 = Nothing
        | otherwise = Just( x `div` y + u `div` v + l `div` k)

    howManyDifferences:: Eq a => [(a,a)] -> Int
    howManyDifferences [] = 0
    howManyDifferences ((x,y):xs)
        | x /= y = 1 + howManyDifferences xs
        | otherwise = howManyDifferences xs

    getDigitsFromCode :: String -> String
    getDigitsFromCode [] = []
    getDigitsFromCode (x:xs)
        | isDigit x = x : getDigitsFromCode xs
        | otherwise = getDigitsFromCode xs

    isTriangularNumber :: Integral a => a -> Bool
    isTriangularNumber num
        | num < 1 = False
        | otherwise = isTriangularNumberHelper num 1 1
            where
                isTriangularNumberHelper num i n
                    | num == n = True 
                    | n > num = False
                    | otherwise = isTriangularNumberHelper num (i+1) (n + i + 1)

    smallestInSize :: [a] -> [b] -> [c] -> Maybe Int
    smallestInSize xs ys zs
        | uniqueMin [lx, ly, lz] == Just lx = Just 1
        | uniqueMin [lx, ly, lz] == Just ly = Just 2
        | uniqueMin [lx, ly, lz] == Just lz = Just 3
        | otherwise = Nothing
        where
            lx = length $ take 1000 xs
            ly = length $ take 1000  ys
            lz = length $ take 1000  zs

            uniqueMin lst
                | length (filter (== minimum lst) lst) == 1 = Just (minimum lst)
                | otherwise = Nothing

    reverseWords :: Integral a => String -> [a] -> String
    reverseWords str n = unwords (reverseWordsH (words str) n 1)
        where
            reverseWordsH [] _ _ = []
            reverseWordsH (x:xs) (n:ns) i
                | n == i = reverse x : reverseWordsH xs ns (i + 1)
                | otherwise = x : reverseWordsH xs (n:ns) (i + 1)

    camelToSnake :: String -> String
    camelToSnake "" = ""
    camelToSnake (x:xs)
        | isUpper x = "_" ++ toLower x : camelToSnake xs
        | otherwise = x : camelToSnake xs

    sumMaybe :: Num a => [Maybe a] -> a
    sumMaybe [] = 0
    sumMaybe (x:xs)
        | isNothing x = 0 + sumMaybe xs
        | otherwise = abs(fromJust x) + sumMaybe xs

    applyIfIncreases :: Ord a => (a -> a) -> [a] -> [a]
    applyIfIncreases f = map (\x ->  max (f x) x)

    elemFreqByFirstOcc :: Eq a => [a] -> [(a, Int)]
    elemFreqByFirstOcc xs = map (\g -> (head g, length g)) (groupByFirstOcc xs)
        where
            groupByFirstOcc [] = []
            groupByFirstOcc (y:ys) =
                (y : filter (== y) ys) : groupByFirstOcc (filter (/= y) ys)
