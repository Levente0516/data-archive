$szavak="alma","korte","banán","ananasz","dinnye"
$i=0
while ($i -lt $szavak.Length)
{
    if ($szavak[$i] -match "^a")
    {
        Write-Host ($szavak[$i], "a-val kezdodik.")
    }
    $i++
}