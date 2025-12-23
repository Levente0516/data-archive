$osszeg=0
foreach($ertek in $args)
{
    $osszeg+=$ertek
}
Write-Host $osszeg