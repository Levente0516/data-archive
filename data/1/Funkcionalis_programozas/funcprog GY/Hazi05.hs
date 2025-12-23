module Hazi05 where
    
    import Data.Char
    
    --1

    toUpperThird :: String -> String
    toUpperThird (x:xs:xss:xsss) = (x:xs:toUpper(xss):xsss)   
    toUpperThird [] = []
    toUpperThird (y:ys) = (y:ys)

    --2

    isSorted :: Ord a => [a] -> Bool
    isSorted [] = True
    isSorted [x] = True
    isSorted (x:xs:xss) = x <= xs && isSorted(xs:xss)

    --3

    (!!!) :: Integral b => [a] -> b -> a
    (!!!) [] _ = error "Nem jo" 
    (!!!) (x:xs) 0 = x
    (!!!) (x:xs) y 
        | y > 0 = xs !!! (y-1)
        | y < 0 = reverse (x:xs) !!! abs(y + 1)

    --4

    format :: Integral b => b -> String -> String
    format 0 szoveg = szoveg
    format y [] = ' ' : format (y-1) []
    format y (x:xs)
        | y < 0 = x : xs 
        | otherwise = x : format (y-1) xs

    --5

    mightyGale :: (Num a, Ord b, Num b, Integral c) => [(String, a, b, c)] -> String
    mightyGale [] = ""
    mightyGale ((x, _, xss, _):ys)
        | xss > 110 = x 
        | xss <= 110 = mightyGale ys

    --6

    cipher :: [Char] -> String
    cipher (x:xs:xss:xsss)
        | isDigit xss = [x, xs] 
        | otherwise = cipher (xs:xss:xsss)
    cipher _ = ""

    --7

    doubleElements :: [a] -> [a]
    doubleElements [] = []
    doubleElements (x:xs) = x : x : doubleElements xs

    --8

    deleteDuplicateSpaces :: String -> String
    deleteDuplicateSpaces = unwords . words