module ShuntingYardBetter where

import Data.Either()
import Data.Maybe()
import Text.Read()
import Data.List()
import Data.Char()

basicInstances = 0 -- Mágikus tesztelőnek kell ez, NE TÖRÖLD!

data Dir = InfixL | InfixR deriving (Show, Eq, Ord)
data Tok a = BrckOpen | BrckClose | TokLit a | TokBinOp (a -> a -> a) Char Int Dir | TokFun (a -> a) String

instance Show a => Show (Tok a) where
  show BrckOpen = "BrckOpen"
  show BrckClose = "BrckClose"
  show (TokLit a) = "TokLit " ++ show a
  show (TokBinOp _ a1 a2 a3) = "TokBinOp " ++ show a1  ++ " " ++ show a2 ++ " " ++ show a3
  show (TokFun _ fuggveny) = "TokFun " ++ fuggveny


instance (Eq a) => Eq (Tok a) where
  (/=) (TokBinOp _ a1 a2 a3) (TokBinOp _ b1 b2 b3) = (a1 /= b1) || (a2 /= b2) || (a3 /= b3)
  (/=) BrckOpen BrckClose = True
  (/=) BrckClose BrckOpen = True
  (/=) (TokLit a)(TokLit b) = True
  (/=) (TokFun _ fuggveny1)(TokFun _ fuggveny2) = True
  (==) (TokBinOp _ a1 a2 a3) (TokBinOp _ b1 b2 b3) = (a1 == b1) && (a2 == b2) && (a3 == b3)
  (==) BrckOpen BrckOpen = True
  (==) BrckClose BrckClose = True
  (==) (TokLit a)(TokLit b) = True
  (==) (TokFun _ fuggveny1)(TokFun _ fuggveny2) = True

type OperatorTable a = [(Char, (a -> a -> a, Int, Dir))]

tAdd, tMinus, tMul, tDiv, tPow :: (Floating a) => Tok a
tAdd = TokBinOp (+) '+' 6 InfixL
tMinus = TokBinOp (-) '-' 6 InfixL
tMul = TokBinOp (*) '*' 7 InfixL
tDiv = TokBinOp (/) '/' 7 InfixL
tPow = TokBinOp (**) '^' 8 InfixR

operatorTable :: (Floating a) => OperatorTable a
operatorTable =
    [ ('+', ((+), 6, InfixL))
    , ('-', ((-), 6, InfixL))
    , ('*', ((*), 7, InfixL))
    , ('/', ((/), 7, InfixL))
    , ('^', ((**), 8, InfixR))
    ]


operatorFromChar :: OperatorTable a -> Char -> Maybe (Tok a)
operatorFromChar [] n = Nothing
operatorFromChar ((x,(y,z,u)):xs) n
    | n == x = Just (TokBinOp y x z u)
    | otherwise = operatorFromChar xs n



getOp :: (Floating a) => Char -> Maybe (Tok a)
getOp = operatorFromChar operatorTable