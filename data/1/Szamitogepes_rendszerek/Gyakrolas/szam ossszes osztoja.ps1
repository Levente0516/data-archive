$a = Read-Host

for ($i=0; $i -lt $a; $i++)
{
    if (($a % $i) -eq 0)
    {
        Write-Host $i
    }
} 