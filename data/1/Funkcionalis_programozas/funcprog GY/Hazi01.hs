module Hazi01 where 
    
    intExpr1 :: Int
    intExpr1 = 1
    
    intExpr2 :: Int
    intExpr2 = 1
    
    intExpr3 :: Int
    intExpr3 = 1

    inc :: Integer -> Integer
    inc x = x + 1

    triple :: Integer -> Integer
    triple x = x * 3

    konstans :: Integer
    konstans = 0

    thirteen1 :: Integer
    thirteen1 = inc(inc(inc(inc(triple(triple(inc(konstans)))))))

    thirteen2 :: Integer
    thirteen2 = inc(inc(inc(inc(inc(inc(inc(triple(inc(inc(konstans))))))))))

    thirteen3 :: Integer 
    thirteen3 = inc(triple(inc(triple(inc(konstans)))))