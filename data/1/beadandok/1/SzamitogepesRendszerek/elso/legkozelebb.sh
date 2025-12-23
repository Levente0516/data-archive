#!/bin/sh

#tömb létrehozása
array=()

#fájl adatai beolvasása a tömbe soronként
while read line; 
do     
    array+=("$line")  
done < "adatok.txt"  

#deklaráció
max_elol=0
max_hatul=0
min_elol=0
min_hatul=0

#az előtte való távolság a 3. index szóval az i=2 lesz
i=2

#maximumkeresés az előtte való távolságra, amely majd a minimumkereséshez kell 
while [ $i -lt ${#array[@]} ]; do
    if [ "${array[i]}" -gt "$max_elol" ]; then
        max_elol=${array[i]}
    fi

    ((i+=4))

done

i=2

min_elol=$max_elol

#minumumkeresés
while [ $i -lt ${#array[@]} ]; do
    if [ "${array[i]}" -lt "$min_elol" ]; then
        min_elol=${array[i]}
    fi

    ((i+=4))

done

#mögötte való távolság a 4. index így i=3
i=3

#maximumkeresés a mögötte lévő távolsághoz ...
while [ $i -lt ${#array[@]} ]; do
    if [ "${array[i]}" -gt "$max_hatul" ]; then
        max_hatul=${array[i]}
    fi

    ((i+=4))

done

i=3

min_hatul=$max_hatul

#minimumkeresés
while [ $i -lt ${#array[@]} ]; do
    if [ "${array[i]}" -lt "$min_hatul" ]; then
        min_hatul=${array[i]}
    fi

    ((i+=4))

done

#összehasonlítás melyik a kisebb előtte vagy mögötte
if [ "$min_elol" -lt "$min_hatul" ]; then
    echo "A legközelebb lévő autó ${min_elol}m-re volt tőle."
else
    echo "A legközelebb lévő autó ${min_hatul}m-re volt tőle."
fi