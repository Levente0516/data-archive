module Vizsga2022_01_10 where

squareSum :: Num a => (a, a) -> (a, a, a)
squareSum (x, y) = (x, y, (x*x + y*y))

names :: [String] -> [String] -> [String]
names [] [] = []
names [] _ = []
names _ [] = []
names (x:xs) (y:ys) = (x ++ " " ++ y) : names xs ys
