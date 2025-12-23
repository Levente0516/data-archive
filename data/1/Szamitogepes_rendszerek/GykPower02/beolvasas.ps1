[double]$a=Read-Host "a "
[double]$b=Read-Host "b "
[double]$c=Read-Host "c "
if ($a -ne 0)
{
    $d=$b*$b-4*$a*$c

    if($d -eq 0)
    {
        $x=(-$b)/(2*$a)
        Write-Host $x 
    }
    elseif ($d -gt 0)
    {
        $d=[math]::Sqrt($d)
        $x1=(-$b-$d)/(2*$a)
        $x2=(-$b+$d)/(2*$a)
        
        Write-Host $x1 
        Write-Host $x2
    }
    else
    {
        Write-Host "Komplex szam lenne!"
    }
}
else
{
    Write-Host "Nem masodfoku!"
}