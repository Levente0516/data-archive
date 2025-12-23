module Vizsga2021masik where

    f5 :: Integral a => a -> a
    f5 n = n `mod` 5 

    matchingArgs :: Eq a => a -> a -> a -> Bool 
    matchingArgs x y z 
        | x == y || x == z || y == z = True
        | otherwise = False

    division :: Integral a => (a, a, a) -> Maybe a
    division (x,0,z) = Nothing
    division (x,y,0) = Nothing
    division (x,y,z)
        | y `mod` z == 0 = Nothing
        | otherwise = Just (x `div` (y `mod` z))

    elemOnEvenIdx :: Eq a => a -> [a] -> Bool
    elemOnEvenIdx n [] = False
    elemOnEvenIdx n list = elemOnEvenIdxHelper n list 1
        where
            elemOnEvenIdxHelper n [] i = False
            elemOnEvenIdxHelper n (x:xs) i
                | n == x && even i = True
                | otherwise = elemOnEvenIdxHelper n xs (i+1)

    dropEveryNth :: Int -> [a] -> [a]
    dropEveryNth n [] = []
    dropEveryNth n list = dropEveryNthHelper n list 1
        where
            dropEveryNthHelper n [] i = []
            dropEveryNthHelper n (x:xs) i
                | i `mod` n == 0 = dropEveryNthHelper n xs (i+1)
                | otherwise = x : dropEveryNthHelper n xs (i+1)