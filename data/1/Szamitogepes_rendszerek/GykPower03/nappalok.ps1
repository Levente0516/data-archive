[int32]$ora=(Get-Date -Format hh)

Write-Host $ora

switch($ora)
{
    {$ora -gt 5 -and $ora -lt 10}
        {Write-Host "Jó reggelt!"}
    {$ora -gt 9 -and $ora -lt 18}
        {Write-Host "Jó napot!"}
    {$ora -gt 17 -and $ora -lt 22}
        {Write-Host "Jó estét!"}
    {$ora -gt 22 -and $ora -le 23 -or $ora -gt 0 -and $ora -lt 5}
        {Write-Host "Jó éjszakát!"}
}