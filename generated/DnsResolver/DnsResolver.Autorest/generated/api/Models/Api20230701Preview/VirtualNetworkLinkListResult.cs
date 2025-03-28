// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Extensions;

    /// <summary>The response to an enumeration operation on virtual network links.</summary>
    public partial class VirtualNetworkLinkListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLinkListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLinkListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLinkListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The continuation token for the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLink[] _value;

        /// <summary>Enumeration of the virtual network links.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLink[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkLinkListResult" /> instance.</summary>
        public VirtualNetworkLinkListResult()
        {

        }
    }
    /// The response to an enumeration operation on virtual network links.
    public partial interface IVirtualNetworkLinkListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IJsonSerializable
    {
        /// <summary>The continuation token for the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The continuation token for the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Enumeration of the virtual network links.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enumeration of the virtual network links.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLink) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLink[] Value { get; set; }

    }
    /// The response to an enumeration operation on virtual network links.
    internal partial interface IVirtualNetworkLinkListResultInternal

    {
        /// <summary>The continuation token for the next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>Enumeration of the virtual network links.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IVirtualNetworkLink[] Value { get; set; }

    }
}