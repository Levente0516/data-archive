module Hazi03 where

    import Data.List
    
    --1a

    isSingleton :: [a] -> Bool
    isSingleton [x] = True
    isSingleton _ = False

    --1b

    exactly2OrAtLeast4 :: [a] -> Bool
    exactly2OrAtLeast4 [] = False
    exactly2OrAtLeast4 [x] = False
    exactly2OrAtLeast4 [x, y, z] = False
    exactly2OrAtLeast4 _ = True

    --2

    firstTwoElements :: [a] -> [a]
    firstTwoElements [] = []
    firstTwoElements [x] = []
    firstTwoElements (x:xs:xss) = [x,xs]

    --3

    withoutThird :: [a] -> [a] 
    withoutThird [] = []
    withoutThird [x] = [x]
    withoutThird [x, y] = [x, y]    
    withoutThird (x:y:z:xs) = (x:y:xs)

    --4

    onlySingletons :: [[a]] -> [[a]]
    onlySingletons [] = []
    onlySingletons hossz =  [[x] | [x] <- hossz, length [x] == 1]

    --5

    compress :: (Eq a, Num b) => [a] -> [(a,b)]
    compress [] = []
    compress xs = [(head g, fromIntegral (length g)) | g <- group xs]

    --6

    decompress :: Integral b => [(a,b)] -> [a]
    decompress [] = []
    decompress ((x, n):xs) = replicate (fromIntegral n) x  ++ decompress xs   

