[float]$a = Read-Host
[float]$b = Read-Host
[float]$c = Read-Host

[float]$s=(($a+$b+$c)/2)

[float]$e=[math]::Sqrt($s * ($s - $a) * ($s - $b) * ($s - $c))

Write-Host $e