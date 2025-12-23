module H3 where

    import Data.List

    isSingleton :: [a] -> Bool
    isSingleton [x] = True
    isSingleton _ = False

    exactly2OrAtLeast4 :: [a] -> Bool
    exactly2OrAtLeast4 [] = False
    exactly2OrAtLeast4 [x] = False
    exactly2OrAtLeast4 [x, y] = True
    exactly2OrAtLeast4 [x, y, z] = False
    exactly2OrAtLeast4 _ = True

    firstTwoElements :: [a] -> [a]
    firstTwoElements [] = []
    firstTwoElements [x] = []
    firstTwoElements [x, y] = [x, y]
    firstTwoElements (x:y:xs) = [x, y] 

    withoutThird :: [a] -> [a]
    withoutThird [] = []
    withoutThird [x] = [x]
    withoutThird [x, y] = [x, y]
    withoutThird [x, y, z] = [x, y]
    withoutThird (x:y:z:xs) = x:y:xs

    onlySingletons :: [[a]] -> [[a]]
    onlySingletons [] = []
    onlySingletons list = [[x] | [x] <- list, length [x] == 1]

    compress :: (Eq a, Num b) => [a] -> [(a,b)]
    compress x = [(head y, fromIntegral (length y)) | y <- group x]

    decompress :: Integral b => [(a,b)] -> [a]
    decompress [] = []
    decompress ((x,n):xs) = replicate (fromIntegral n) x ++ decompress xs