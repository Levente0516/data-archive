do 
{
    Write-Host "============================"
    Write-Host "Válasszon az alábbi listából:"
    Write-Host "0 - Folyamatok listázása"
    Write-Host "1 - Mai dátum"
    Write-Host "2 - Kilépés"
    Write-Host "============================"
    $v=Read-Host

    switch($v)
    {
        "0" {Get-Process}
        "1" {Get-Date}
        "2" {break}
        default {Write-Host "Érvénytelen billentyűt adtál meg"; break}
    }
} while($v -ne "2")