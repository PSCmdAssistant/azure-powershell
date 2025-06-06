// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Runtime.Extensions;

    /// <summary>Response of payload to be passed while installing VM agent.</summary>
    public partial class VMExtensionPayload :
        Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IVMExtensionPayload,
        Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IVMExtensionPayloadInternal
    {

        /// <summary>Backing field for <see cref="EnvironmentId" /> property.</summary>
        private string _environmentId;

        /// <summary>Id of the environment created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Origin(Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.PropertyOrigin.Owned)]
        public string EnvironmentId { get => this._environmentId; set => this._environmentId = value; }

        /// <summary>Backing field for <see cref="IngestionKey" /> property.</summary>
        private string _ingestionKey;

        /// <summary>Ingestion key of the environment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Origin(Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.PropertyOrigin.Owned)]
        public string IngestionKey { get => this._ingestionKey; set => this._ingestionKey = value; }

        /// <summary>Creates an new <see cref="VMExtensionPayload" /> instance.</summary>
        public VMExtensionPayload()
        {

        }
    }
    /// Response of payload to be passed while installing VM agent.
    public partial interface IVMExtensionPayload :
        Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Runtime.IJsonSerializable
    {
        /// <summary>Id of the environment created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Id of the environment created",
        SerializedName = @"environmentId",
        PossibleTypes = new [] { typeof(string) })]
        string EnvironmentId { get; set; }
        /// <summary>Ingestion key of the environment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Ingestion key of the environment",
        SerializedName = @"ingestionKey",
        PossibleTypes = new [] { typeof(string) })]
        string IngestionKey { get; set; }

    }
    /// Response of payload to be passed while installing VM agent.
    internal partial interface IVMExtensionPayloadInternal

    {
        /// <summary>Id of the environment created</summary>
        string EnvironmentId { get; set; }
        /// <summary>Ingestion key of the environment</summary>
        string IngestionKey { get; set; }

    }
}