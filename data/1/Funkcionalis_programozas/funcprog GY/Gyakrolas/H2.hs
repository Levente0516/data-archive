module H2 where

    cmpRem5Rem7 :: Int -> Bool
    cmpRem5Rem7 x = x `mod` 5 > x `mod` 7 

    foo :: Int -> Bool -> Bool
    foo x y = x > 3 && y

    bar :: Bool -> Int -> Bool
    bar x z = foo z x 

    addV :: (Double,Double) -> (Double,Double) -> (Double,Double)
    addV (x,y) (u,v) = (x + u , y + v)
    
    subV :: (Double,Double) -> (Double,Double) -> (Double,Double)
    subV (x,y) (u,v) = (x - u , y - v)

    scaleV :: Double -> (Double,Double) -> (Double,Double)
    scaleV x (z,y) = (x * z, x * y)

    scalar :: (Double,Double) -> (Double,Double) -> Double
    scalar (x,y) (u,v) = x*u + y*v

    divides :: Integral a => a -> a -> Bool
    divides 0 0 = True
    divides 0 _ = False
    divides x y = y `mod` x == 0

    add :: (Integral a, Integral b, Num c) => a -> b -> c
    add x y = fromIntegral x + fromIntegral y