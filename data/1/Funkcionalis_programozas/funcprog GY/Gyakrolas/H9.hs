{-module H9 where

    data ListWithHoles a = Nil | Cons a (ListWithHoles a) | Hole (ListWithHoles a) deriving Eq

    instance (Eq a, Show a) => Show (ListWithHoles a) where
        show list = "[" ++ showElements list ++ "]"
            where
                showElements :: (Eq a, Show a) => ListWithHoles a -> String
                showElements Nil = ""
                showElements (Cons x Nil) = show x
                showElements (Cons x xs) = show x ++ "," ++ showElements xs
                showElements (Hole xs)
                    | xs == Nil = "_" ++ "" ++ showElements xs
                    | otherwise = "_" ++ "," ++ showElements xs
    

    dehole :: ListWithHoles a -> [a]
    dehole Nil = []
    dehole (Cons x xs) = x : dehole xs
    dehole (Hole xs) = dehole xs

    fromMaybeList :: [Maybe a] -> ListWithHoles a
    fromMaybeList [] = Nil
    fromMaybeList (Nothing : xs) = Hole (fromMaybeList xs)
    fromMaybeList (Just x : xs) = Cons x (fromMaybeList xs)

    preserveHoles :: ListWithHoles a -> [Maybe a]
    preserveHoles Nil = []
    preserveHoles (Hole xs) = Nothing : preserveHoles xs
    preserveHoles (Cons x xs) = Just x : preserveHoles xs

    fillHoles :: ListWithHoles a -> a -> [a]
    fillHoles Nil _ = []
    fillHoles (Hole xs) n = n : fillHoles xs n 
    fillHoles (Cons x xs) n = x : fillHoles xs n 

    data NonEmptyList b = Last b | NECons b (NonEmptyList b) deriving Eq

    instance Show a => Show (NonEmptyList a) where
    show list2 = "[" ++ showElements2 list2 ++ "]"
        where
            showElements2 (Last x) = show x
            showElements2 (NECons x xs) = show x ++ "," ++ showElements2 xs
-}