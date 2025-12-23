module Fact where

    fact 0 = 1
    fact n = n * fact(n-1)

    fact' n = product [1..  n] 