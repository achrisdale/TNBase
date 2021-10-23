param(
    [Parameter(Mandatory=$true)]
    [string]$version
)

$path = .\TNBase.Setup\TNBase.Setup.vdproj
$project = Get-Content $path

$project = $project.Replace('"ProductVersion" = "8:1.0.0.0"', '"ProductVersion" = "8:' + $version + '"')

$guid = New-Guid
$productCode = '"ProductCode" = "8:{' + $guid.ToString().ToUpper()
$project = $project -replace '"ProductCode" = "8:{[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}', $productCode

$guid = New-Guid
$packageCode = '"PackageCode" = "8:{' + $guid.ToString().ToUpper()
$project = $project -replace '"PackageCode" = "8:{[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}', $packageCode

Set-Content $path -Value $project

$path = .\TNBase\TNBase.csproj
$project = Get-Content $path

$project = $project.Replace("<Version>1.0.0.0</Version>", "<Version>$version</Version>")

Set-Content $path -Value $project
