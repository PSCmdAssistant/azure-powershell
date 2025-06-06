
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
Create an in-memory object for UsernamePasswordAuthTypeWorkspaceConnectionProperties.
.Description
Create an in-memory object for UsernamePasswordAuthTypeWorkspaceConnectionProperties.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.UsernamePasswordAuthTypeWorkspaceConnectionProperties
.Link
https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject
#>
function New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.UsernamePasswordAuthTypeWorkspaceConnectionProperties')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter()]
        [string]
        $CredentialsPassword,
        [Parameter(HelpMessage="Optional, required by connections like SalesForce for extra security in addition to UsernamePassword.")]
        [string]
        $CredentialsSecurityToken,
        [Parameter()]
        [string]
        $CredentialsUsername,
        [Parameter(HelpMessage="Category of the connection.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ConnectionCategory])]
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ConnectionCategory]
        $Category,
        [Parameter()]
        [System.DateTime]
        $ExpiryTime,
        [Parameter()]
        [bool]
        $IsSharedToAll,
        [Parameter(HelpMessage="Store user metadata for this connection.")]
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IWorkspaceConnectionPropertiesV2Metadata]
        $Metadata,
        [Parameter()]
        [string[]]
        $SharedUserList,
        [Parameter()]
        [string]
        $Target,
        [Parameter(HelpMessage="Value details of the workspace connection.")]
        [string]
        $Value,
        [Parameter(HelpMessage="format for the workspace connection value.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ValueFormat])]
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ValueFormat]
        $ValueFormat
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.UsernamePasswordAuthTypeWorkspaceConnectionProperties]::New()
        $object.AuthType = "UsernamePassword"
        
        if ($PSBoundParameters.ContainsKey('CredentialsPassword')) {
            $Object.CredentialsPassword = $CredentialsPassword
        }
        if ($PSBoundParameters.ContainsKey('CredentialsSecurityToken')) {
            $Object.CredentialsSecurityToken = $CredentialsSecurityToken
        }
        if ($PSBoundParameters.ContainsKey('CredentialsUsername')) {
            $Object.CredentialsUsername = $CredentialsUsername
        }
        if ($PSBoundParameters.ContainsKey('Category')) {
            $Object.Category = $Category
        }
        if ($PSBoundParameters.ContainsKey('ExpiryTime')) {
            $Object.ExpiryTime = $ExpiryTime
        }
        if ($PSBoundParameters.ContainsKey('IsSharedToAll')) {
            $Object.IsSharedToAll = $IsSharedToAll
        }
        if ($PSBoundParameters.ContainsKey('Metadata')) {
            $Object.Metadata = $Metadata
        }
        if ($PSBoundParameters.ContainsKey('SharedUserList')) {
            $Object.SharedUserList = $SharedUserList
        }
        if ($PSBoundParameters.ContainsKey('Target')) {
            $Object.Target = $Target
        }
        if ($PSBoundParameters.ContainsKey('Value')) {
            $Object.Value = $Value
        }
        if ($PSBoundParameters.ContainsKey('ValueFormat')) {
            $Object.ValueFormat = $ValueFormat
        }
        return $Object
    }
}

