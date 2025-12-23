param ([int]$n)
$fakt=1
for ($i=1;$i -le $n;$i++)
{
    $fakt*=$i
}
Write-Host $fakt