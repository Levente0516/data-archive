module Hazi02 where

    --Hazi01

    --4

    cmpRem5Rem7 :: Int -> Bool 
    cmpRem5Rem7 x = ((x `mod` 5) >= (x `mod` 7))

    --5

    foo :: Int -> Bool -> Bool
    foo x y = (x > 0) && y

    bar :: Bool -> Int -> Bool
    bar z u = foo u z 
    
    --Hazi02

    --1

    addV :: (Double,Double) -> (Double,Double) -> (Double,Double)
    addV (a1,a2) (b1, b2) = (a1 + b1 , a2 + b2)

    subV :: (Double,Double) -> (Double,Double) -> (Double,Double)
    subV (a1,a2) (b1,b2) = (a1 - b1 , a2 - b2)

    --2

    scaleV :: Double -> (Double,Double) -> (Double,Double)
    scaleV skal (a1, a2) = (a1 * skal, a2 * skal)

    --3

    scalar :: (Double,Double) -> (Double,Double) -> Double
    scalar (a1,a2) (b1,b2) = (a1 * b1) + (a2 * b2)

    --4

    divides :: Integral a => a -> a -> Bool
    divides 0 0 = True
    divides 0 _ = False
    divides x y = y `mod` x == 0

    --5

    add :: (Integral a, Integral b, Num c) => a -> b -> c
    add x y = fromIntegral x + fromIntegral y

