write-Host "x `tcos(X)"

for ($i=0; $i -lt 1; $i=$i+0.1)
{
    $x=$i
    $s=[Math]::Round([Math]::Cos($x),5)
    Write-Host "$x `t$s"
}