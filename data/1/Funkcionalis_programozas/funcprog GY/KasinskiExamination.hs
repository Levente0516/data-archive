module KasinskiExamination where

    import Data.List

    type Cipher = String
    type Term = String

    isPrefixRepeated :: Int -> Cipher -> Bool
    isPrefixRepeated 0 str = True
    isPrefixRepeated n [] = False
    isPrefixRepeated n str = isPrefixRepeatedHelper (take n str) (drop n str) n
        where
            isPrefixRepeatedHelper z [] n = False
            isPrefixRepeatedHelper z x n
                | z == take n x = True
                | otherwise = isPrefixRepeatedHelper z (drop 1 x) n
            

    repetitionOfLen :: Int -> Cipher -> [Term]
    repetitionOfLen 0 str = []
    repetitionOfLen n [] = []
    repetitionOfLen n str = repetitionOfLenHelper str (drop 1 str) n
        where 
            repetitionOfLenHelper z [] n = []
            repetitionOfLenHelper z x n
                | take n z == take n x = take n z : repetitionOfLenHelper (drop 1 z) (drop 1 x) n
                | otherwise = repetitionOfLenHelper z (drop 1 x) n

    repetitions :: Cipher -> [Term]
    repetitions [] = []
    repetitions str = nub $ concat [repetitionsHelper n str (drop n str) | n <- [3..length str]] 
        where
            repetitionsHelper n x [] = []
            repetitionsHelper n [] y = []
            repetitionsHelper n x y
                | take n x == take n y = take n x : repetitionsHelper n (drop 1 x) y
                | otherwise = repetitionsHelper n x (drop 1 y)

    termStartPositions :: Term -> Cipher -> [Int]
    termStartPositions [] [] = []
    termStartPositions [] chi = []
    termStartPositions chi [] = []
    termStartPositions ter chi = termStartPositionsHelper ter chi 0
        where
            termStartPositionsHelper [] y i = []
            termStartPositionsHelper x [] i = []
            termStartPositionsHelper x y i
                | take (length x) y == x = i : termStartPositionsHelper x (drop 1 y) (i + 1)
                | otherwise = termStartPositionsHelper x (drop 1 y) (i + 1)


    differences :: [Int] -> [Int]
    differences [] = []
    differences [x] = []
    differences (x:y:xs) = y - x : differences (y:xs)

    repeatedTermDistances :: Cipher -> [Int]
    repeatedTermDistances [] = []
    repeatedTermDistances str = concatMap (\term -> differences (termStartPositions term str)) (repetitions str)

    divisors :: Int -> [Int]
    divisors n = divisorsHelper n [1..n `div` 2] ++ [n]
        where   
            divisorsHelper y [] = []
            divisorsHelper y (z:zs)
                | y `mod` z == 0 = z : divisorsHelper y zs
                | otherwise = divisorsHelper y zs

    factors :: [Int] -> [Int]
    factors [] = []
    factors inte = sort [y | x <- inte, y <- [3..x], x `mod` y == 0]


    type KeyLength = Int
    type Frequency = Int

    analyseCipher :: Cipher -> [(Frequency, KeyLength)]
    analyseCipher [] = []
    analyseCipher str = sort $ gyakroisag (factors(repeatedTermDistances str))
        where 
            gyakroisag xs = [(length g, head g) | g <- group(sort xs)]