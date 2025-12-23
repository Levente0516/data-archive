module Viszga_gyakorlas_sok where

    import Data.Char (toUpper, toLower)
    import Data.Maybe (fromJust, fromMaybe)

    concatTripleString :: ([Char], [Char], [Char]) ->[Char]
    concatTripleString (x , y , z) = x ++ y ++ z

    mods :: Integral a => a -> a -> Maybe (a, a)
    mods 0 _ = Nothing
    mods _ 0 = Nothing
    mods x y = Just (x `mod ` y, y `mod` x)

    dropEmpties :: Eq a => [[a]] -> [[a]]
    dropEmpties [] = []
    dropEmpties (x:xs)
        | null x = dropEmpties xs
        | otherwise =  x : dropEmpties xs

    createChain :: Integer -> String
    createChain 0 = ""
    createChain int = [x | y <- [1..int],  x <- "(" ++ show y ++ ")"]

    aLtErNaTiNgCaPs :: String -> String
    aLtErNaTiNgCaPs "" = ""
    aLtErNaTiNgCaPs (x:xs) = helper (x:xs) 0
        where
            helper [] i = ""
            helper (x:xs) i
                | i `mod` 2 == 0 = toLower x : helper xs (i+1)
                | otherwise = toUpper x : helper xs (i+1)

    result :: [Maybe Bool] -> Int -> Bool
    result [] _ = False
    result list i
        | resultHelper list 0 >= i = True
        | otherwise = False
            where
                resultHelper :: [Maybe Bool] -> Int -> Int
                resultHelper [] n = n
                resultHelper (x:xs) n
                    | x == Just True = resultHelper xs (n+1)
                    | x == Just False = resultHelper xs (n-1)
                    | otherwise = resultHelper xs n

    maximumIF :: Ord a => (a -> Bool) -> [a] -> Maybe a
    maximumIF felt [] = Nothing
    maximumIF felt (x:xs) = maximumIFHelper xs (felt x) x
        where
            maximumIFHelper [] True currentMax = Just currentMax
            maximumIFHelper [] False _ = Nothing
            maximumIFHelper (y:ys) True currentMax
                | felt y && y > currentMax = maximumIFHelper ys True y
                | otherwise = maximumIFHelper ys True currentMax
            maximumIFHelper (y:ys) False _
                | felt y = maximumIFHelper ys True y
                | otherwise = maximumIFHelper ys False y

    fillBlanks :: String -> String -> String
    fillBlanks [] _ = []
    fillBlanks str [] = str
    fillBlanks (x:xs) (y:ys)
        | x == '_' = y : fillBlanks xs ys
        | otherwise = x : fillBlanks xs (y:ys) 

    riffleShuffle :: [a] -> [a]
    riffleShuffle [] = []
    riffleShuffle [x] = [x]
    riffleShuffle list = riffleShuffleHelper firstH secondH
        where
            (firstH, secondH) = splitAt (length list `div` 2) list

            riffleShuffleHelper :: [a] -> [a] -> [a]
            riffleShuffleHelper [] lab = lab
            riffleShuffleHelper fej [] = fej
            riffleShuffleHelper (x:xs)(y:ys) = x : y : riffleShuffleHelper xs ys

    getPositions :: Eq a => a -> [a] -> Maybe [Int]
    getPositions _ [] = Nothing
    getPositions n list 
        | getPositionsHelper n list 1 == [] = Nothing
        | otherwise = Just (getPositionsHelper n list 1) 
            where
                getPositionsHelper :: Eq a => a -> [a] -> Int -> [Int]
                getPositionsHelper n [] i = []
                getPositionsHelper n (x:xs) i
                    | x == n = i : getPositionsHelper n xs (i+1)
                    | otherwise = getPositionsHelper n xs (i+1)
    
    applies :: [a -> b] -> [a] -> [b]
    applies [] _ = []
    applies _ [] = []
    applies func list = concat [map f list | f <- func]

    data FiniteList = Empty | NonEmpty Int [Integer] deriving (Show, Eq)

    toFinite :: Int -> [Integer] -> FiniteList
    toFinite _ [] = Empty
    toFinite szam list
        | null $ take szam list = Empty
        | otherwise = NonEmpty (length $ take szam list) (take szam list)

    concatFL :: [FiniteList] -> FiniteList
    concatFL [Empty] = Empty
    concatFL list
        | all (== Empty) list = Empty
    concatFL list = NonEmpty (length $ concat $ nonEmptyList list) (concat $ nonEmptyList list)
        where 
            nonEmptyList list = [xs | NonEmpty _ xs <- list]


    difference :: String -> String -> Maybe String
    difference [] [] = Nothing 
    difference [] _  = Nothing  
    difference (x:xs) [] = Just (x:xs)
    difference (x:xs) (y:ys)
        | x == y    = difference xs ys 
        | otherwise = Just (x : fromMaybe [] (difference xs ys))  

    filterByMajority :: [(a -> Bool)] -> [a] -> [a]
    filterByMajority [] [] = []
    filterByMajority [] list = list
    filterByMajority fact [] = []
    filterByMajority fact list = helperr fact list
        where
            helperr _ [] = []
            helperr facts (y:ys)
                | doing facts y = y : helperr facts ys
                | otherwise = helperr facts ys
            
            doing facts x = length (filter ($ x) facts) > (length facts `div` 2)