// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication extension model custom properties.</summary>
    public partial class ReplicationExtensionModelCustomProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.IReplicationExtensionModelCustomProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.IReplicationExtensionModelCustomPropertiesInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Discriminator property for ReplicationExtensionModelCustomProperties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>
        /// Creates an new <see cref="ReplicationExtensionModelCustomProperties" /> instance.
        /// </summary>
        public ReplicationExtensionModelCustomProperties()
        {

        }
    }
    /// Replication extension model custom properties.
    public partial interface IReplicationExtensionModelCustomProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Discriminator property for ReplicationExtensionModelCustomProperties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Discriminator property for ReplicationExtensionModelCustomProperties.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Replication extension model custom properties.
    internal partial interface IReplicationExtensionModelCustomPropertiesInternal

    {
        /// <summary>Discriminator property for ReplicationExtensionModelCustomProperties.</summary>
        string InstanceType { get; set; }

    }
}