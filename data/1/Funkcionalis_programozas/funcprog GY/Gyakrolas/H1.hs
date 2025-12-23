module H1 where

    inc :: Integer -> Integer
    inc x = x + 1

    triple :: Integer -> Integer
    triple x = x*3

    thirteen1 :: Integer
    thirteen1 = inc $ inc $ inc $ inc $ triple $ triple $ inc 0

    thirteen2 :: Integer
    thirteen2 = inc $ triple $ inc $ inc $ inc $ inc 0
    
    thirteen3 :: Integer
    thirteen3 = inc $ triple $ inc $ triple $ inc 0