Write-Host "Magyar-Angol szótár"
$szotar=@{kutya="dog";macska="cat";eger="mouse"}
Write-Host "Magyar: `t Angol:"
$magyar=Read-Host
foreach($magyar in $szotar.Keys)
{
    Write-Host($magyar,"`t->`t",$szotar[$magyar])
}