param (
    [string]$projectName,
    [string]$slnName,
    [string]$slnPath = ".\"
)

Write-Host "Creating project pair for: $projectName"

$projectPath = "$($slnPath)\$($projectName)\$($projectName).csproj"
$projectTestPath = "$($slnPath)\$($projectName).Tests\$($projectName).Tests.csproj"
$slnFullPath = "$($slnPath)\$($slnName).sln"

# dotnet new classlib -f net9.0 --no-restore --name $projectName
# New Project
New-Item -Path $projectPath -ItemType File -Force
Add-Content -Path $projectPath -Value '<Project Sdk="Microsoft.NET.Sdk"></Project>'



# dotnet new mstest -f net9.0 --sdk --test-runner VSTest --coverage-tool coverlet --extensions-profile AllMicrosoft --fixture None --name "$($projectName).Tests"
# New Test Project
New-Item -Path $projectTestPath -ItemType File -Force
Add-Content -Path $projectTestPath -Value '<Project Sdk="MSTest.Sdk/3.6.4"></Project>'

dotnet sln $slnFullPath add --in-root $projectPath
dotnet sln $slnFullPath add --in-root $projectTestPath