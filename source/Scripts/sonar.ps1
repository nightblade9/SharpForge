###
# Updates SonarQube with the latest information about the codebase.
#
#
# Installation:
# 1) Install SonarQube and its dependencies (e.g. OpenJDK)
# 2) Decide on a project name, and set it in $ProjectName
# 2) Create a new (.NET) project in SonarQube, with the project name, and with a new token that never expires; paste the token contents into sonarToken.txt.
# 3) Install the cli pre-requisites:
#   dotnet tool install --global dotnet-sonarscanner
#   dotnet tool install --global dotnet-coverage
###

###
# Usage: Start SonarQube, then run .\sonar.ps1
###

###
# Best practices:
# In SonarQube, under Adminstration > New Code, set the Number of Days to a low value like 1
###

####################

$ProjectName = "Forge"

$ErrorActionPreference = "Stop"
$sonarToken = [System.IO.File]::ReadAllText("sonarToken.txt")
$stopWatch = New-Object -TypeName System.Diagnostics.StopWatch
$stopWatch.Start()

dotnet sonarscanner begin /k:"$ProjectName" /d:sonar.host.url="http://localhost:9000" /d:sonar.login=$sonarToken /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml /d:sonar.test.exclusions=**/*Test*.cs /d:sonar.inclusions=**/SharpForge*/**/*

dotnet build --no-incremental
# Assumes no end-to-end tests. If they exist, add to the dotnet test command: --filter FullyQualifiedName!~EndToEnd
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"

dotnet sonarscanner end /d:sonar.login=$sonarToken

$stopWatch.Stop()
$minutes = $stopWatch.Elapsed.minutes
$seconds = $stopWatch.Elapsed.seconds
Write-Host "Done in $minutes minutes, $seconds seconds!"