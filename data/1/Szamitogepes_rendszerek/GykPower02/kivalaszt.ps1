param($fnev)
if (Test-Path $fnev)
{
    $tartalom=Get-Content $fnve
    for ($i=0; $i -le $tartalom.Length; $i++)
    {
        Write-Host ($i+1)$tartalom[$i]
    }
}
else
{
    Write-Host "Nem létezik"
}