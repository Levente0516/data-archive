module Hazi07 where

    import Data.List

    --1

    --a

    data TriBool = Yes | Maybe | No
        deriving (Show, Eq)

    --b

    instance Ord TriBool where
        No <= _ = True
        Yes <= _ = False
        Maybe <= Yes = True
        Maybe <= No = False
        Maybe <= Maybe = True

        No >= _ = False
        Yes >= _ = True
        Maybe >= Yes = False
        Maybe >= No = False
        Maybe >= Maybe = True

        No < _ = True
        Yes < _ = False
        Maybe < No = False
        Maybe < Yes = True

        No > _ = False
        Yes > _ = True
        Maybe > Yes = False
        Maybe > No = True

    --c

    triOr :: TriBool -> TriBool -> TriBool
    triOr Yes No = Yes
    triOr No Yes = Yes
    triOr Yes Yes = Yes
    triOr Yes Maybe = Yes
    triOr Maybe Yes = Yes
    triOr Maybe No = Maybe
    triOr No Maybe = Maybe
    triOr Maybe Maybe = Maybe
    triOr No No = No

    --c

    triAnd :: TriBool -> TriBool -> TriBool
    triAnd Yes No = No
    triAnd No Yes = No
    triAnd Yes Yes = Yes
    triAnd Yes Maybe = Maybe
    triAnd Maybe Yes = Maybe
    triAnd Maybe Maybe = Maybe
    triAnd Maybe No = No
    triAnd No Maybe = No
    triAnd No No = No

    --d

    incMonotonityTest :: (Integral i, Ord a) => i -> [a] -> TriBool
    incMonotonityTest n xs
        | not (sorted first) = No
        | hosszabb (fromIntegral n) xs = Maybe
        | otherwise = Yes
        where
            first = take (fromIntegral n) xs

    hosszabb :: Int -> [a] -> Bool
    hosszabb 0 (_:_) = True
    hosszabb _ [] = False
    hosszabb n (_:xs) = hosszabb (n-1) xs

    sorted :: Ord a => [a] -> Bool
    sorted [] = True
    sorted [_] = True
    sorted (x:y:xs) = x <= y && sorted (y:xs)   
   
    --2

    --a

    data GolfScore = Ace | Albatross | Eagle | Birdie | Par | Bogey Integer
        deriving Show 

    instance Eq GolfScore where
        Ace == Ace = True
        Albatross == Albatross = True
        Eagle == Eagle = True
        Birdie == Birdie = True
        Par == Par = True
        Bogey _  == Bogey _ = True
        _ == _ = False

    --b

    score :: Integer -> Integer -> GolfScore
    score x y
        | y == 1 = Ace
        | (y + 3) <= x = Albatross
        | (y + 2) == x = Eagle
        | (y + 1) == x = Birdie
        | y == x = Par
        | y > x = Bogey (y-x)

    --3

    --a

    data Time = T Int Int
        deriving Eq

    --b

    t :: Int -> Int -> Time
    t x y 
        | (x < 0 || x > 23) && (y < 0 || y > 59) = error "Nem jó"
        | otherwise = T x y

    --c

    instance Show Time where
        show (T x y) = format x ++ ":" ++ format y
            where
                format z
                    | z < 10 = "0" ++ show z
                    | otherwise = show z 
    
    --d

    instance Ord Time where
        (T x1 y1) <= (T x2 y2) = (x1, y1) < (x2, y2)

    --e

    isBetween :: Time -> Time -> Time -> Bool
    isBetween x1 x2 x3 
        | x1 <= x2 && x2 <= x3 = True 
        | x3 <= x2 && x2 <= x1 = True
        | otherwise = False

    --f

    data USTime = AM Int Int | PM Int Int
        deriving Eq

    --g

    ustimeAM :: Int -> Int -> USTime
    ustimeAM x y
        | (x < 1 || x > 12) && (y < 0 || y > 59) = error "Nem jó"
        | otherwise = AM x y

    ustimePM :: Int -> Int -> USTime
    ustimePM x y
        | (x < 1 || x > 12) && (y < 0 || y > 59) = error "Nem jó"
        | otherwise = PM x y

    --h

    instance Show USTime where
        show (AM x y) = "AM " ++ show x ++ ":" ++ format y
            where
                format z
                    | z < 10 = "0" ++ show z
                    | otherwise = show z
        show (PM x y) = "PM " ++ show x ++ ":" ++ format y
            where
                format z
                    | z < 10 = "0" ++ show z
                    | otherwise = show z 

    --i

    instance Ord USTime where
        compare x1 x2 = compare (change x1) (change x2)
            where
                change :: USTime -> (Int,Int)
                change (AM 12 y) = (0, y) 
                change (AM x y) = (x, y)
                change (PM 12 y) = (12, y)
                change (PM x y) = (x + 12, y)
    
    --j

    ustimeToTime :: USTime -> Time
    ustimeToTime (AM 12 y) = T 0 y
    ustimeToTime (AM x y) = T x y
    ustimeToTime (PM 12 y) = T 12 y
    ustimeToTime (PM x y) = T (x + 12) y 

    --k

    timeToUSTime :: Time -> USTime
    timeToUSTime (T x y)
        | x == 0 = AM 12 y
        | x == 12 = PM 12 y
        | x > 12 = PM (x-12) y
        | otherwise = AM x y