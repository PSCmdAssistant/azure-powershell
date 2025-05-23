// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Extensions;

    /// <summary>
    /// MatchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels map is equivalent to an element of
    /// matchExpressions, whose key field is "key", the operator is "In", and the values array contains only "value". The requirements
    /// are ANDed.
    /// </summary>
    public partial class VolumeClaimSpecSelectorMatchLabels :
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IVolumeClaimSpecSelectorMatchLabels,
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IVolumeClaimSpecSelectorMatchLabelsInternal
    {

        /// <summary>Creates an new <see cref="VolumeClaimSpecSelectorMatchLabels" /> instance.</summary>
        public VolumeClaimSpecSelectorMatchLabels()
        {

        }
    }
    /// MatchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels map is equivalent to an element of
    /// matchExpressions, whose key field is "key", the operator is "In", and the values array contains only "value". The requirements
    /// are ANDed.
    public partial interface IVolumeClaimSpecSelectorMatchLabels :
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.IAssociativeArray<string>
    {

    }
    /// MatchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels map is equivalent to an element of
    /// matchExpressions, whose key field is "key", the operator is "In", and the values array contains only "value". The requirements
    /// are ANDed.
    internal partial interface IVolumeClaimSpecSelectorMatchLabelsInternal

    {

    }
}