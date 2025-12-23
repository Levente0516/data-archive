module Hazi08 where

    import Data.Ratio

    data LucasNum = LucasNum Rational
        deriving Eq

    instance Show LucasNum where
        show (LucasNum a) = show a

    instance Num LucasNum where
        (+)(LucasNum a1)(LucasNum a2) = LucasNum (a1+a2)
        (*)(LucasNum a1)(LucasNum a2) = LucasNum (a1*a2)
        negate (LucasNum a)= LucasNum (-a)
        abs (LucasNum a) = LucasNum (abs a)
        signum (LucasNum a) = LucasNum (signum a)
        fromInteger i = LucasNum (fromInteger i)

    golden :: LucasNum
    golden = LucasNum ((1 + (161 % 72))/2)

    {-lucas :: (Integral a, Num b) => a -> b
    lucas n = fromRational(goldenV ^ n + (1 - goldenV) ^ n)
        where (LucasNum goldenV) = golden-}