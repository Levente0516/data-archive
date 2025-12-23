module ProbaZh where

    import Data.List

    --1
    points :: Integral a => [(String, a, a)] -> [(String, a)]
    points [] = []
    points ((name,time,fail):xs)
        | (100 - (time `div` 2) - fail) < 0 = points xs 
        | fail == 100 = points xs
        | otherwise = (name , 100 - (time `div` 2) - fail) : points xs

    --2

    type Apple = (Bool, Int)
    type Tree = [Apple]
    type Garden = [Tree]

    ryuksApples :: Garden -> Int
    ryuksApples [] = 0
    ryuksApples (fa:xs) = ryuksApplesHelper fa + ryuksApples xs
        where
            ryuksApplesHelper [] = 0
            ryuksApplesHelper ((erett, magassag):xs)
                | erett && magassag <= 3 = 1 + ryuksApplesHelper xs
                | otherwise = ryuksApplesHelper xs

    --3

    doesContain :: String -> String -> Bool
    doesContain [] _ = True
    doesContain _ [] = False
    doesContain (x:xs) (y:ys)
        | x == y = doesContain xs ys
        | otherwise = doesContain (x:xs) ys

    --4

    barbie :: [String] -> String
    barbie szoknya = barbieHelper szoknya 1
        where 
            barbieHelper [] _ = "farmer"
            barbieHelper (x:xs) i
                | x == "fekete" = barbieHelper xs (i+1)
                | x == "rozsaszin" = "rozsaszin"
                | even i = x
                | otherwise = barbieHelper xs (i+1) 
    --5

    firstValid :: [a -> Bool] -> a -> Maybe Int
    firstValid predi x = firstValidHelper predi 0
        where
            firstValidHelper [] _ = Nothing
            firstValidHelper (p:ps) i
                | p x = Just i
                | otherwise = firstValidHelper ps (i + 1)

    --6

    combineListsIf :: (a -> b -> Bool) -> (a -> b -> c) -> [a] -> [b] -> [c]
    combineListsIf _ _ [] _ = []
    combineListsIf _ _ _ [] = []
    combineListsIf p f (x:xs) (y:ys)
        | p x y = f x y : combineListsIf p f xs ys
        | otherwise = combineListsIf p f xs ys

    --7

    data Line = Tram Integer [String] | Bus Integer [String] deriving (Eq, Show)

    whichBusStop :: String -> [Line] -> [Integer]
    whichBusStop str [] = []
    whichBusStop str (Bus num stops : xs)
        | str `elem` stops = num : whichBusStop str xs
        | otherwise = whichBusStop str xs
    whichBusStop str (Tram num stops : ys)
        | str `elem` stops = whichBusStop str ys
        | otherwise = whichBusStop str ys

    --8

    isReservable :: Int -> String -> Bool
    isReservable 0 "" = True
    --isReservable _ "" = False
    isReservable n str
        | {-isPrefixOf "x" str &&-} length (filter (== 'x' ) (take 100 str)) >= n = True
        | otherwise = False 