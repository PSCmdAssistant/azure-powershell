$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMapsCreator.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMapsCreator' {
    It 'CreateExpanded' -Skip {
        {  
          New-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName03 -Name $env.creatorName03 -Location $env.creatorLocation -StorageUnit 3
        } | Should -Not -Throw
    }
}
