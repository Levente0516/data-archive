module H8 where

    import Data.Ratio

    data LucasNum = LucasNum Rational deriving Eq

    instance Show LucasNum where
        show (LucasNum a) = show (round a :: Integer)

    instance Num LucasNum where
        (+)(LucasNum a1)(LucasNum a2) = LucasNum (a1+a2)
        (-)(LucasNum a1)(LucasNum a2) = LucasNum (a1-a2)
        (*)(LucasNum a1)(LucasNum a2) = LucasNum (a1*a2)
        negate (LucasNum a)= LucasNum (-a)
        abs (LucasNum a) = LucasNum (abs a)
        signum (LucasNum a) = LucasNum (signum a)
        fromInteger i = LucasNum (fromInteger i)

    lucas :: Integral a => a -> LucasNum
    lucas n = let φ = LucasNum ((1 + 5374978561 % 2403763488) / 2)
        in φ ^ n + ((1 - φ) ^ n)