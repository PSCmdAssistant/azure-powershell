// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Wrapper model for OSVersion to include version and service pack info.</summary>
    public partial class OSVersionWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IOSVersionWrapper,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IOSVersionWrapperInternal
    {

        /// <summary>Backing field for <see cref="ServicePack" /> property.</summary>
        private string _servicePack;

        /// <summary>The service pack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServicePack { get => this._servicePack; set => this._servicePack = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="OSVersionWrapper" /> instance.</summary>
        public OSVersionWrapper()
        {

        }
    }
    /// Wrapper model for OSVersion to include version and service pack info.
    public partial interface IOSVersionWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The service pack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The service pack.",
        SerializedName = @"servicePack",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePack { get; set; }
        /// <summary>The version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Wrapper model for OSVersion to include version and service pack info.
    internal partial interface IOSVersionWrapperInternal

    {
        /// <summary>The service pack.</summary>
        string ServicePack { get; set; }
        /// <summary>The version.</summary>
        string Version { get; set; }

    }
}