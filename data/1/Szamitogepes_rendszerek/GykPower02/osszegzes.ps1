$osszeg=0
if ($args.Count -gt 0)
{
    for ($i=0;$i -lt $args.Count;$i++)
    {
        $osszeg+=$args[$i]
    }
    Write-Host $osszeg
}
else
{
    Write-Host "Nem adott meg semmilyen paramétert!"
}