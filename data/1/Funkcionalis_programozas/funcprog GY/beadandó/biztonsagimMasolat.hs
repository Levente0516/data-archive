import Data.Either
import Data.Maybe
import Text.Read
import Data.List
import Data.Char

basicInstances = 0 -- Mágikus tesztelőnek kell ez, NE TÖRÖLD!

data Dir = InfixL | InfixR deriving (Show, Eq, Ord)
data Tok a = BrckOpen | BrckClose | TokLit a | TokBinOp (a -> a -> a) Char Int Dir | TokFun (a -> a) String

data ShuntingYardError = OperatorOrClosingParenExpected | LiteralOrOpeningParenExpected | NoClosingParen | NoOpeningParen | ParseError deriving (Show, Eq)

type ShuntingYardResult a = Either ShuntingYardError a

type FunctionTable a = [(String, a -> a)]

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
operatorFromChar [] _ = Nothing
operatorFromChar ((jel, (jel2, ertek, kotes)) : xs) x
  | x == jel = Just (TokBinOp jel2 x ertek kotes)
  | otherwise = operatorFromChar xs x

getOp :: (Floating a) => Char -> Maybe (Tok a)
getOp = operatorFromChar operatorTable

-------------------------------------

splitTokens :: String -> [String]
splitTokens [] = []
splitTokens (x:xs)
  | x == '('  = "(" : splitTokens xs
  | x == ')'  = ")" : splitTokens xs
  | isDigit x = (x : takeWhile isDigit xs) : splitTokens (dropWhile isDigit xs)
  | x == ' '  = splitTokens xs
  | otherwise = [x] : splitTokens xs

check :: OperatorTable a -> Char -> Bool
check [] _ = False
check ((jel, (jel2, ertek, kotes)) : xs) y
            | y == jel = True
            | otherwise = check xs y

getTok :: OperatorTable a -> Char -> [Tok a]
getTok [] _ = []
getTok ((jel, (jel2, ertek, kotes)) : xs) y
  | y == jel = [TokBinOp jel2 y ertek kotes]
  | otherwise = getTok xs y

decide :: OperatorTable a -> String -> Bool
decide y token
  | isBrckBrck token = fv y (splitTokens token)
  | otherwise = fv y (words token)

fv :: OperatorTable a -> [String] -> Bool
fv y [] = False
fv y (x:xs)
  | check y (head x) || x == "(" || x == ")" || isJust (readMaybe x :: Maybe Int) || isJust (readMaybe x :: Maybe Double) || isJust (readMaybe x :: Maybe Char) || isJust (readMaybe x :: Maybe String) || isJust (readMaybe x :: Maybe Ordering) || x == "True" || x == "False" = fv y xs
  | otherwise = True

isBrckBrck :: String -> Bool
isBrckBrck [] = False
isBrckBrck [_] = False
isBrckBrck (x:y:xs)
  | (x == '(' || x == ')') && not (null [y]) && (y == '(' || y == ')') = True
  | otherwise = isBrckBrck xs

invalidOp :: OperatorTable a -> String -> Bool
invalidOp _ [] = False
invalidOp _ [_] = False
invalidOp y (x:z:xs)
  | check y x && check y z = True
  | check y x && (z == 'T' || z == 'F') = True
  | check y x && x /= '-' && (isJust (readMaybe [z] :: Maybe Int) || isJust (readMaybe [z] :: Maybe Double)) = True
  | check y z && z /= '-' && (isJust (readMaybe [x] :: Maybe Int) || isJust (readMaybe [x] :: Maybe Double)) = True
  | otherwise = invalidOp y (z:xs)

invalidTokLit :: [String] -> Bool
invalidTokLit [] = False
invalidTokLit [_] = False
invalidTokLit (x:y:xs)
  | (isJust (readMaybe x :: Maybe Int) || isJust (readMaybe x :: Maybe Double)) && not (null y) && ((head y) == '-' || (head y) == '+') && (isJust (readMaybe (tail y) :: Maybe Int) || isJust (readMaybe (tail y) :: Maybe Double)) = True
  | otherwise = invalidTokLit xs

isNotInf :: OperatorTable a -> String -> Bool
isNotInf _ [] = False
isNotInf _ [_] = False
isNotInf y (x:z:xs)
  | check y z && x == z = True
  | otherwise = isNotInf y xs

opTableHelper :: OperatorTable a -> OperatorTable a
opTableHelper [] = []
opTableHelper [x] = [x]
opTableHelper ((jel, (jel2, ertek, kotes)) : ((jel', (jel2', ertek', kotes')) : xs))
  | jel == jel' = []
  | otherwise = (jel, (jel2, ertek, kotes)) : opTableHelper ((jel', (jel2', ertek', kotes')):xs)


parseTokens :: Read a => OperatorTable a -> String -> Maybe [Tok a]
parseTokens _ [] = Just []
parseTokens y token = parseTokensH (opTableHelper (take 10 y)) token
  where
    parseTokensH y token
      | isNotInf y (take 10 token) = Nothing
      | all (==' ') token = Just []
      | invalidTokLit (words token) = Nothing
      | decide y token = Nothing
      | invalidOp y token = Nothing
      | isBrckBrck token = Just (parseTokensHelper y (splitTokens token))
      | otherwise =  Just (parseTokensHelper y (words token))
          where
              parseTokensHelper _ [] = []
              parseTokensHelper y (z:zs)
                  | z == "(" = BrckOpen : parseTokensHelper y zs
                  | z == ")" = BrckClose : parseTokensHelper y zs
                  | z == "True" = TokLit (fromJust (readMaybe z)) : parseTokensHelper y zs
                  | z == "False" = TokLit (fromJust (readMaybe z)) : parseTokensHelper y zs
                  | check y (head z) && length z == 1 = getTok y (head z) ++ parseTokensHelper y zs
                  | otherwise = TokLit (fromJust (readMaybe z)) : parseTokensHelper y zs

parse :: String -> Maybe [Tok Double]
parse = parseTokens operatorTable

-----------------------

isLiteral :: Tok a -> Bool
isLiteral (TokLit _) = True
isLiteral _ = False

fromLiteral :: Tok a -> a
fromLiteral (TokLit x) = x

isOp :: Tok a -> Bool
isOp (TokBinOp _ _ _ _) = True
isOp _ = False

isBrckOpen :: Tok a -> Bool
isBrckOpen BrckOpen = True
isBrckOpen _ = False

isBrckClose :: Tok a -> Bool
isBrckClose BrckClose = True
isBrckClose _ = False

solverHelper :: ([a], [Tok a]) -> ([a], [Tok a])
solverHelper (xs, []) = (xs, [])
solverHelper (xs, BrckOpen : op) = (xs, op)
solverHelper (x:z:xs, TokBinOp o _ _ _ : op) = solverHelper (o z x : xs, op)

shuntingYardBasic :: [Tok a] -> ([a], [Tok a])
shuntingYardBasic [] = ([],[])
shuntingYardBasic tokens = shuntingYardBasicHelper tokens ([],[]) 
  where
    shuntingYardBasicHelper [] (literals, op) = (literals, op) 
    shuntingYardBasicHelper (x:xs) (literals, op)
      | isLiteral x = shuntingYardBasicHelper xs ([fromLiteral x] ++ literals, op)
      | isOp x = shuntingYardBasicHelper xs (literals, [x] ++ op)
      | isBrckOpen x && null xs = shuntingYardBasicHelper xs (literals, [x] ++ op)
      | isBrckOpen x = shuntingYardBasicHelper xs (literals, [x] ++ op)
      | isBrckClose x = shuntingYardBasicHelper xs (solverHelper (literals, op))
      | otherwise = shuntingYardBasicHelper xs (literals, op)

parseAndEval :: (String -> Maybe [Tok a]) -> ([Tok a] -> ([a], [Tok a])) -> String -> Maybe ([a], [Tok a])
parseAndEval parse eval input = maybe Nothing (Just . eval) (parse input)

syNoEval :: String -> Maybe ([Double], [Tok Double])
syNoEval = parseAndEval parse shuntingYardBasic

syEvalBasic :: String -> Maybe ([Double], [Tok Double])
syEvalBasic = parseAndEval parse (\t -> shuntingYardBasic $ BrckOpen : (t ++ [BrckClose]))

precedenceSolver :: Tok a -> [a] -> [Tok a] -> ([a], [Tok a])
precedenceSolver x literals [] = (literals, [x])
precedenceSolver x literals operators@(BrckOpen : op) = (literals, x : operators)
precedenceSolver x@(TokBinOp _ _ e1 i1) literals@(y:z:ys) operators@((TokBinOp o _ e2 i2) : op)
  | e2 > e1 || ((i1 == InfixL) && (e2 >= e1)) = precedenceSolver x ((o z y): ys) op
  | otherwise = (literals, x : operators)

shuntingYardPrecedence :: [Tok a] -> ([a], [Tok a])
shuntingYardPrecedence [] = ([],[])
shuntingYardPrecedence tokens = shuntingYardPrecedenceHelper tokens ([],[]) 
  where
    shuntingYardPrecedenceHelper [] (literals, op) = (literals, op) 
    shuntingYardPrecedenceHelper (x:xs) (literals, op)
      | isLiteral x = shuntingYardPrecedenceHelper xs ([fromLiteral x] ++ literals, op)
      | isOp x = shuntingYardPrecedenceHelper xs (precedenceSolver x literals op)
      | isBrckOpen x && null xs = shuntingYardPrecedenceHelper xs (literals, [x] ++ op)
      | isBrckOpen x = shuntingYardPrecedenceHelper xs (literals, [x] ++ op)
      | isBrckClose x = shuntingYardPrecedenceHelper xs (solverHelper (literals, op))
      | otherwise = shuntingYardPrecedenceHelper xs (literals, op)

syEvalPrecedence :: String -> Maybe ([Double], [Tok Double])
syEvalPrecedence = parseAndEval parse (\t -> shuntingYardPrecedence $ BrckOpen : (t ++ [BrckClose]))


--eqError-t vedd ki a kommentből, ha megcsináltad az 1 pontos "Hibatípus definiálása" feladatot
eqError = 0 -- Mágikus tesztelőnek szüksége van rá, NE TÖRÖLD!

{-
-- Ezt akkor vedd ki a kommentblokkból, ha a 3 pontos "A parser és az algoritmus újradefiniálása" feladatot megcsináltad.
parseAndEvalSafe ::
    (String -> ShuntingYardResult [Tok a]) ->
    ([Tok a] -> ShuntingYardResult ([a], [Tok a])) ->
    String -> ShuntingYardResult ([a], [Tok a])
parseAndEvalSafe parse eval input = either Left eval (parse input)

sySafe :: String -> ShuntingYardResult ([Double], [Tok Double])
sySafe = parseAndEvalSafe
  (parseSafe operatorTable)
  (\ts -> shuntingYardSafe (BrckOpen : ts ++ [BrckClose]))
-}


-- Ezt akkor vedd ki a kommentblokkból, ha az 1 pontos "Függvénytábla és a típus kiegészítése" feladatot megcsináltad.
tSin, tCos, tLog, tExp, tSqrt :: Floating a => Tok a
tSin = TokFun sin "sin"
tCos = TokFun cos "cos"
tLog = TokFun log "log"
tExp = TokFun exp "exp"
tSqrt = TokFun sqrt "sqrt"

functionTable :: (RealFrac a, Floating a) => FunctionTable a
functionTable =
    [ ("sin", sin)
    , ("cos", cos)
    , ("log", log)
    , ("exp", exp)
    , ("sqrt", sqrt)
    , ("round", (\x -> fromIntegral (round x :: Integer)))
    ]

tRound :: (Floating a, RealFrac a) => Tok a 
tRound = TokFun (\x -> fromIntegral (round x :: Integer)) "round"

{-
-- Ezt akkor vedd ki a kommentblokkból, ha a 2 pontos "Függvények parse-olása és kiértékelése" feladatot megcsináltad.
syFun :: String -> Maybe ([Double], [Tok Double])
syFun = parseAndEval
  (parseWithFunctions operatorTable functionTable)
  (\t -> shuntingYardWithFunctions $ BrckOpen : (t ++ [BrckClose]))
-}

{-
-- Ezt akkor vedd ki a kommentblokkból, ha minden más feladatot megcsináltál ez előtt.
syComplete :: String -> ShuntingYardResult ([Double], [Tok Double])
syComplete = parseAndEvalSafe
  (parseComplete operatorTable functionTable)
  (\ts -> shuntingYardComplete (BrckOpen : ts ++ [BrckClose]))
-}
