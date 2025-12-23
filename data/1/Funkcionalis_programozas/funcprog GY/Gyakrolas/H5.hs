module H5 where

    import Data.Char

    toUpperThird :: String -> String
    toUpperThird [x] = [x]
    toUpperThird [x, y] = [x, y]
    toUpperThird [x, y, z] = [x, y, toUpper z]
    toUpperThird (x:y:z:xs) = x:y:toUpper z:xs

    isSorted :: Ord a => [a] -> Bool
    isSorted [] = True
    isSorted [x] = True
    isSorted (x:y:xs)
        | y >= x = isSorted xs
        | otherwise = False

    (!!!) :: Integral b => [a] -> b -> a
    (!!!) [] n = error "Nem jó"  
    (!!!) (x:xs) 0 = x
    (!!!) (x:xs) n
        | n > 0 = xs !!! (n-1)
        | n < 0 = reverse (x:xs)  !!! abs (n + 1)

    format :: Integral b => b -> String -> String
    format 0 str = str
    format n []
        | n < 0 = []
        | otherwise = ' ' : format (n-1) []
    format n (x:xs)
        | n < 0 = x : xs
        | otherwise = x : format (n-1) xs

    mightyGale :: (Num a, Ord b, Num b, Integral c) => [(String, a, b, c)] -> String
    mightyGale [] = ""
    mightyGale ((name, _, speed, _):xs)
        | speed > 110 = name
        | otherwise = mightyGale xs

    cipher :: String -> String
    cipher (x:y:z:xs)
        | isDigit z = [x , y]
        | otherwise = cipher (y:z:xs) 
    cipher _ = ""

    doubleElements :: [a] -> [a]
    doubleElements [] = []
    doubleElements (x:xs) = x : x : doubleElements xs

    deleteDuplicateSpaces :: String -> String
    deleteDuplicateSpaces x = unwords $ words x