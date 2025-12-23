module Vizsga2021 where

    byDunaOrTisza :: String -> Bool
    byDunaOrTisza [] = False
    byDunaOrTisza str
        | length str < 5 = False
        | otherwise = helper str
            where
                helper [] = False
                helper str
                    | take 5 str == "Tisza" || take 4 str == "Duna" = True
                    | otherwise = False

    howManyDoubles :: Eq a => [[a]] -> Int
    howManyDoubles [] = 0
    howManyDoubles [[]] = 0
    howManyDoubles (x:xs)
        | help x = 1 + howManyDoubles xs
        | otherwise = howManyDoubles xs
            where 
                help [] = False
                help [z] = False
                help (x:y:xs)
                    | x == y = True
                    | otherwise = False 

    blackJackPoints :: Integral a => [a] -> Maybe a
    blackJackPoints [] = Nothing
    blackJackPoints list
        | nope list = blackJackPointsHelper (sum list)
        | otherwise = Nothing
        where
            blackJackPointsHelper x
                | x > 21 = Nothing
                | otherwise = Just x

            nope [] = True
            nope (x:xs)
                | x > 11 = False
                | otherwise = nope xs

    notDivisibleByThree :: Integral a => [a] -> Maybe Int
    notDivisibleByThree [] = Nothing
    notDivisibleByThree list
        | isListAll list == length (take 100 list) = Nothing
        | otherwise = isDivisible list 1
            where
                isListAll [] = 0
                isListAll (x:xs)
                    | x `mod` 3 == 0 = 1 + isListAll xs
                    | otherwise = isListAll xs

                isDivisible [] i = Nothing
                isDivisible (x:xs) i
                    | x `mod` 3 == 0  && x /= 0 = Just i
                    | otherwise = isDivisible xs (i+1)