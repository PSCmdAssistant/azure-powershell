
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an in-memory object for ImageTemplateDistributor.
.Description
Create an in-memory object for ImageTemplateDistributor.
.Example
New-AzImageBuilderTemplateDistributorObject -ManagedImageDistributor -ArtifactTag @{tag='azpstest'} -ImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image" -RunOutputName "runoutput-01" -Location eastus
.Example
New-AzImageBuilderTemplateDistributorObject -ArtifactTag @{tag='vhd'} -VhdDistributor -RunOutputName image-vhd
.Example
New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{"test"="dis-share"} -GalleryImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image" -ReplicationRegion "eastus" -RunOutputName "runoutput-01"

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ImageTemplateManagedImageDistributor
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ImageTemplateSharedImageDistributor
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ImageTemplateVhdDistributor
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ARTIFACTTAG <IImageTemplateDistributorArtifactTags>: Tags that will be applied to the artifact once it has been created/updated by the distributor.
  [(Any) <String>]: This indicates any property can be added to this object.

TARGETREGION <ITargetRegion[]>: The target regions where the distributed Image Version is going to be replicated to. This object supersedes replicationRegions and can be specified only if replicationRegions is not specified.
  Name <String>: The name of the region.
  [ReplicaCount <Int32?>]: The number of replicas of the Image Version to be created in this region. Omit to use the default (1).
  [StorageAccountType <String>]: Specifies the storage account type to be used to store the image in this region. Omit to use the default (Standard_LRS).

VERSIONING <IDistributeVersioner>: Describes how to generate new x.y.z version number for distribution.
  Scheme <String>: Version numbering scheme to be used.
.Link
https://learn.microsoft.com/powershell/module/az.ImageBuilder/new-azimagebuildertemplatedistributorobject
#>
function New-AzImageBuilderTemplateDistributorObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ImageTemplateManagedImageDistributor], [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ImageTemplateSharedImageDistributor], [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ImageTemplateVhdDistributor])]
[CmdletBinding(DefaultParameterSetName='VhdDistributor', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # The name to be used for the associated RunOutput.
    ${RunOutputName},

    [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Resource Id of the Managed Disk Image.
    ${ImageId},

    [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Azure location for the image, should match if image already exists.
    ${Location},

    [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Distribute as a Managed Disk Image.
    ${ManagedImageDistributor},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageTemplateDistributorArtifactTags]
    # Tags that will be applied to the artifact once it has been created/updated by the distributor.
    ${ArtifactTag},

    [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Resource Id of the Azure Compute Gallery image.
    ${GalleryImageId},

    [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Distribute via Shared Image Gallery.
    ${SharedImageDistributor},

    [Parameter(ParameterSetName='SharedImageDistributor')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Boolean]
    # Flag that indicates whether created image version should be excluded from latest.
    # Omit to use the default (false).
    ${ExcludeFromLatest},

    [Parameter(ParameterSetName='SharedImageDistributor')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String[]]
    # [Deprecated] A list of regions that the image will be replicated to.
    # This list can be specified only if targetRegions is not specified.
    # This field is deprecated - use targetRegions instead.
    ${ReplicationRegion},

    [Parameter(ParameterSetName='SharedImageDistributor')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PSArgumentCompleterAttribute("Standard_LRS", "Standard_ZRS", "Premium_LRS")]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # [Deprecated] Storage account type to be used to store the shared image.
    # Omit to use the default (Standard_LRS).
    # This field can be specified only if replicationRegions is specified.
    # This field is deprecated - use targetRegions instead.
    ${StorageAccountType},

    [Parameter(ParameterSetName='SharedImageDistributor')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.ITargetRegion[]]
    # The target regions where the distributed Image Version is going to be replicated to.
    # This object supersedes replicationRegions and can be specified only if replicationRegions is not specified.
    ${TargetRegion},

    [Parameter(ParameterSetName='SharedImageDistributor')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IDistributeVersioner]
    # Describes how to generate new x.y.z version number for distribution.
    ${Versioning},

    [Parameter(ParameterSetName='VhdDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Distribute via VHD in a storage account.
    ${VhdDistributor},

    [Parameter(ParameterSetName='VhdDistributor')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Optional Azure Storage URI for the distributed VHD blob.
    # Omit to use the default (empty string) in which case VHD would be published to the storage account in the staging resource group.
    ${Uri}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        
        $testPlayback = $false
        $PSBoundParameters['HttpPipelinePrepend'] | Foreach-Object { if ($_) { $testPlayback = $testPlayback -or ('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.PipelineMock' -eq $_.Target.GetType().FullName -and 'Playback' -eq $_.Target.Mode) } }

        if ($null -eq [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion) {
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion = $PSVersionTable.PSVersion.ToString()
        }         
        $preTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        if ($preTelemetryId -eq '') {
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId =(New-Guid).ToString()
            [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.module]::Instance.Telemetry.Invoke('Create', $MyInvocation, $parameterSet, $PSCmdlet)
        } else {
            $internalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
            if ($internalCalledCmdlets -eq '') {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $MyInvocation.MyCommand.Name
            } else {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets += ',' + $MyInvocation.MyCommand.Name
            }
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = 'internal'
        }

        $mapping = @{
            ManagedImageDistributor = 'Az.ImageBuilder.custom\New-AzImageBuilderTemplateDistributorObject_ManagedImageDistributor';
            SharedImageDistributor = 'Az.ImageBuilder.custom\New-AzImageBuilderTemplateDistributorObject_SharedImageDistributor';
            VhdDistributor = 'Az.ImageBuilder.custom\New-AzImageBuilderTemplateDistributorObject_VhdDistributor';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
        if ($null -ne $MyInvocation.MyCommand -and [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PromptedPreviewMessageCmdlets -notcontains $MyInvocation.MyCommand.Name -and [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.MessageAttributeHelper]::ContainsPreviewAttribute($cmdInfo, $MyInvocation)){
            [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.MessageAttributeHelper]::ProcessPreviewMessageAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PromptedPreviewMessageCmdlets.Enqueue($MyInvocation.MyCommand.Name)
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        if ($wrappedCmd -eq $null) {
            $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Function)
        }
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }

    finally {
        $backupTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        $backupInternalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
    }

}
end {
    try {
        $steppablePipeline.End()

        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $backupTelemetryId
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $backupInternalCalledCmdlets
        if ($preTelemetryId -eq '') {
            [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.module]::Instance.Telemetry.Invoke('Send', $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        }
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $preTelemetryId

    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
} 
}
