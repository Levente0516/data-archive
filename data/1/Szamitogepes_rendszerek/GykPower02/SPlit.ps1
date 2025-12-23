param[$fnev]
$tartalom=@()
$tartalom+=Get-Content $fnev
for ($i=0; $i -lt $tartalom.Length; $i++)
{
    $elso=$tartalom[$i].Split()[0]
    $masodik=$tartalom[$i].Split()[1]
    Write-Host $masodik $elso
}