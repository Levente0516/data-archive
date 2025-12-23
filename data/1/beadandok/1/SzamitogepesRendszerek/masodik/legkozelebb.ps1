$lista=@()

Get-Content "adatok.txt" | ForEach-Object { $lista += $_ }
$length=$lista.Length

$i=2
$min_elol= $lista[$i]

while ($i -lt $lista.Length)
{
    if ($lista[$i] -lt $min_elol)
    {
        $min_elol = $lista[$i]
    }
    $i += 4
}

$i=3
[int]$min_hatul=$lista[$i]

while ($i -lt $lista.Length)
{
    if ([int]$lista[$i] -le [int]$min_hatul)
    {
        $min_hatul = $lista[$i]
    }
    $i += 4
}

if ($min_elol -lt $min_hatul)
{
    Write-Host $min_elol
}
else
{
    Write-Host $min_hatul
}