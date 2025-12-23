[int]$szam=Read-Host "Kérem az egész számot"
$prim=@()
$i=2
while($szam -gt 1)
{
    if (($szam%$i) -eq 0)
    {
        $szam=$szam/$i
        $prim += $i
    }
    else
    {
        $i++
    }
}

foreach ($elem in $prim)
{
    $elem
}