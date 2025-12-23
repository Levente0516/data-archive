module Vizsga_sokadik where

    import Data.Char

    splitQuadruple :: (a,b,c,d) -> ((a,b),(c,d))
    splitQuadruple (x,y,z,u) = ((x,y),(z,u))

    dist1 :: Num a => a -> a -> a
    dist1 x y = abs (y - x)

    kroeneckerDelta :: Eq a => a -> a -> Int
    kroeneckerDelta x y 
        | x == y = 1
        | otherwise = 0

    freq :: Eq a => a -> [a] -> Int
    freq char list = length $ filter (== char) list

    {-
    hasUpperCase :: String -> Bool
    hasUpperCase [] = False
    hasUpperCase (x:xs)
        | isUpper x = True
        | otherwise = hasUpperCase xs
    -}

    hasUpperCase :: String -> Bool
    hasUpperCase = any isUpper

    identifier :: String -> Bool
    identifier x = isUpper $ head x

    replace :: Int -> a -> [a] -> [a]
    replace num char list = replaceHelper num char list 0
        where
            replaceHelper num char [] i = []
            replaceHelper num char (x:xs) i
                | num == i = char : replaceHelper num char xs (i+1)
                | otherwise = x : replaceHelper num char xs (i+1) 

    paripos :: [Int] -> Bool
    paripos x = pariposHelper x 0
        where
            pariposHelper [] i = True
            pariposHelper (x:xs) i
                | even i && even x = pariposHelper xs (i+1)
                | odd i && odd x  = pariposHelper xs (i+1)
                | otherwise = False

    safeDiv :: Int -> Int -> Maybe Int
    safeDiv _ 0 = Nothing
    safeDiv x y = Just(div x y)

    parseCSV :: String -> [String]
    parseCSV [] = [""]
    parseCSV str = go str []
        where
            go [] acc = reverse (reverse acc : [])
            go (x:xs) acc
                | x == ';'  = reverse acc : go xs []
                | otherwise = go xs (x : acc)

    c :: (a -> b -> c) -> (b -> a -> c)
    c x y z = x z y

    selectUnless :: (t -> Bool) -> (t -> Bool) -> [t] -> [t]
    selectUnless _ _ [] = []
    selectUnless fact1 fact2 (x:xs)
        | fact1 x && not (fact2 x) = x : selectUnless fact1 fact2 xs
        | otherwise = selectUnless fact1 fact2 xs

    w :: (a -> a -> a) -> a -> a
    w x y = x y y