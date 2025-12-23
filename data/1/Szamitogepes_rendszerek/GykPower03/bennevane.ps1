 $tomb="kutya","macska","kenguru","aladár","kecske","hello","szia","alma","kő","nem"

 Write-Host "Adjon meg egy szot:"
 $szo=Read-Host

 $t=0

 for($i=0;$i -lt $tomb.Length; $i++)
 {
    if ($szo -match $tomb[$i])
    {
        Write-Host $szo, "benne van a listában."
        $t=0
    }
    $t++;
 }
 if($t -eq $tomb.Length)
 {
    Write-Host $szo, "nincs benne a listában."
 }